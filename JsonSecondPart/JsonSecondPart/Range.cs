//using System;
//using Xunit;

//namespace JsonSecondPart
//{
//    public class Range : IPattern
//    {
//        readonly char start;
//        readonly char end;

//        public Range(char start, char end)
//        {
//            this.start = start;
//            this.end = end;
//        }

//        public IMatch Match(string text)
//        {
//            SuccessMatch first = new SuccessMatch(text);

//            if (string.IsNullOrEmpty(text))
//            {
//                return first;
//            }
            
//            if(text[0] >= start && text[0] <= end)
//            {
//                first.SetSucces(true);
//            }

//            return first;
//        }
//    }
//}
