using System;
using System.Collections.Generic;
using System.Text;

namespace Mobile.Control
{
    /// <summary>
    /// Generic event argument class
    /// </summary>
    /// <typeparam name="T">Type of the argument</typeparam>
    public class CheckedChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventArgs"/> class.
        /// </summary>
        /// <param name = "chkd"></param>
        public CheckedChangedEventArgs(bool chkd)
        {
            this.IsChecked = chkd;
        }

        /// <summary>
        /// Gets the value of the event argument
        /// </summary>
        public bool IsChecked { get; private set; }
    }
}
