using System;
using System.Collections.Generic;
using System.Text;

namespace SoftwareKobo.VttToSrt.Core
{
    public static class VttToSrt
    {
        public static string Convert(string vtt)
        {
            if (vtt.StartsWith("WEBVTT") == false)
            {
                throw new ArgumentException("not support", "vtt");
            }
            // remove "WEBVTT"
            vtt = vtt.Substring(6);

            var spans = vtt.Split(new[] { "\r\n\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            var srt = new List<string>();
            var index = 1;
            for (int i = 0; i < spans.Length; i++)
            {
                var span = spans[i];
                span = span.Trim('\r', '\n');
                srt.Add(index.ToString());

                var array = span.Split(new[] { "\r\n" }, StringSplitOptions.None);
                srt.AddRange(array);
                srt.Add(Environment.NewLine);

                index++;
            }
            var temp = string.Join(Environment.NewLine, srt);
            return temp.Replace("\r\n\r\n", "\r\n");
        }
    }
}