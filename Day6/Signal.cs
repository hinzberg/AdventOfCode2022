using System;
using System.Reflection;

namespace Day6
{
	public class Signal
	{
		public string _input { get; set; }

		public Signal(string input)
		{
			_input = input;
		}

		public int FindStartOfMessage()
		{
			int startOfMessageMarkerLength = 14;

            var chars = _input.ToCharArray();

            int marking = 0;
            for (int index = 0; index <= chars.Count() - startOfMessageMarkerLength; index++)
			{
				List<char> charList = new List<char>();

				for (int charIndex = 0; charIndex < startOfMessageMarkerLength; charIndex++)
				{
					charList.Add(chars[index + charIndex]);
				}

                var distinctCount = charList.Distinct().Count();
                if (distinctCount == startOfMessageMarkerLength)
				{
                    marking = index + startOfMessageMarkerLength;
					break;
                }                    
            }
			return marking;
        }

		public int FindStartOfPacketMarker()
		{
			var chars = _input.ToCharArray();

			int marking = 0;
			for (int index = 0; index <= chars.Count() - 4 ; index++)
			{
				var c0 = chars[index];
                var c1 = chars[index+1];
                var c2 = chars[index+2];
                var c3 = chars[index+3];

				if (c0 != c1 && c0 != c2 && c0 != c3 &&
					c1 != c0 && c1 != c2 && c1 != c3 &&
                    c2 != c0 && c2 != c1 && c2 != c3 &&
                    c3 != c0 && c3 != c1 && c3 != c2
                    )
				{
					marking = index + 4;
					break;
                }               
			}
			return marking;
        }
	}
}

