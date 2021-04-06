using System;
using System.Collections.Generic;
using System.Text;

namespace JsonSecondPart
{
    public class InternetDateTimeFormat : IPattern
    {
        private readonly IPattern pattern;

        public InternetDateTimeFormat()
        {
            var digit = new Range('0', '9');
            var date_fullyear = new Sequence(digit, digit, digit, digit);
            var date_month = new Sequence(digit, digit);
            var date_mday = new Sequence(digit, digit);

            var time_hour = new Sequence(digit, digit);
            var time_minute = new Sequence(digit, digit);
            var time_second = new Sequence(digit, digit);
            var time_secfrac = new Sequence(new Character('.'), digit, digit);
            var time_numoffset = new Sequence(new Choice(new Character('+'), new Character('-')), time_hour, new Character(':'), time_minute);
            var time_offset = new Choice(new Character('Z'), time_numoffset);

            var partial_time = new Sequence(time_hour, new Character(':'), time_minute, new Character(':'), time_second, new Optional(time_secfrac));
            var full_date = new Sequence(date_fullyear, new Character('-'), date_month, new Character('-'), date_mday);
            var full_time = new Sequence(partial_time, time_offset);

            var date_time = new Sequence(full_date, new Character('T'), full_time);
            pattern = date_time;

        }
         
        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
