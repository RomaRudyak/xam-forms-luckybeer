using System;
using Xamarin.Forms;

namespace LuckyBeer.StateKit
{
    [ContentProperty("Content")]
    public class StateCondition : View
    {
        public object State { get; set; }
        public View Content { get; set; }
    }
}
