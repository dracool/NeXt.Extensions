using System;
using System.IO;
using System.Net.WebSockets;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NeXt.Extensions.WebSockets
{
    public static class WebSocketExtensions
    {
        private static async Task<string> ReceiveMessageAsync(this WebSocket ws, byte[] buffer, CancellationToken ct)
        {
            var buf = new ArraySegment<byte>(buffer);
            using (var stream = new MemoryStream())
            {
                WebSocketReceiveResult res;
                do
                {
                    res = await ws.ReceiveAsync(buf, ct);
                    stream.Write(buffer, 0, res.Count);
                } while (!res.EndOfMessage);

                return Encoding.UTF8.GetString(stream.ToArray());
            }
        }

        public static async Task<bool> SendMessageAsync(this WebSocket socket, string text)
        {
            if (socket == null) throw new ArgumentNullException(nameof(socket));
            if (text == null) throw new ArgumentNullException(nameof(text));

            var start = 0;
            var data = Encoding.UTF8.GetBytes(text);

            while (start < data.Length)
            {
                var count = start + Math.Min(1024, data.Length - start);
                using (var cts = new CancellationTokenSource(5000))
                {
                    try
                    {
                        await socket.SendAsync(
                            new ArraySegment<byte>(data, start, count),
                            WebSocketMessageType.Text,
                            start + count + 1 >= data.Length,
                            cts.Token
                        ).ConfigureAwait(false);
                    }
                    catch (TaskCanceledException)
                    {
                        return false;
                    }
                }
                start += count + 1;
            }
            return true;
        }

        public static IObservable<string> AsObservable(this WebSocket socket, CancellationToken token)
        {
            if (socket == null) throw new ArgumentNullException(nameof(socket));
            var buffer = new byte[1024];

            return Observable.Using(() => socket,
                ws => Observable.Defer(() => ReceiveMessageAsync(ws, buffer, token).ToObservable())
                    .Repeat()
                    .Publish()
                    .RefCount()
            );
        }
    }
}
