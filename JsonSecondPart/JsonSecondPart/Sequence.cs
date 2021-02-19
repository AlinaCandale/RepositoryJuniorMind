//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace JsonSecondPart
//{
//    public class Sequence : IPattern
//    {
//        IPattern[] patterns;

//        public Sequence(params IPattern[] patterns)
//        {
//            this.patterns = patterns;
//        }

//        public IMatch Match(string text)
//        {
//            Match first = new Match(text);

//            foreach (var item in patterns)
//            {
//                if (item.Match(text).Success())
//                {
//                    first.SetSucces(true);
//                    first.RemainingText();
//                }
//            }

//            return first;

//        }
//    }
//}
