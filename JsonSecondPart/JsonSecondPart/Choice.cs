﻿//using System;
//using System.Collections.Generic;
//using System.Text;
//using Xunit;

//namespace JsonSecondPart
//{
//    public class Choice : IPattern
//    {
//        IPattern[] patterns;
        
//        public Choice(params IPattern[] patterns)
//        {
//            this.patterns = patterns;
//        }

//        public IMatch Match(string text)
//        {
//            SuccessMatch first = new SuccessMatch(text);

//            foreach (var item in patterns )
//            {
//               if (item.Match(text).Success())
//                {
//                    first.SetSucces(true);
//                }
//            }
            
//            return first;
//        }
//    }
//}
