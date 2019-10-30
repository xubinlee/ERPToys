using DevExpress.XtraEditors.Repository;
using Microsoft.Practices.CompositeUI.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary.Client
{
    public class RepositoryItemCommandAdapter : EventCommandAdapter<RepositoryItem>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryItemCommandAdapter"/> class
        /// </summary>
        public RepositoryItemCommandAdapter()
            : base()
        {
        }

        /// <summary>
        /// Initializes the adapter with the given <see cref="ToolStripItem"/>.
        /// </summary>
        public RepositoryItemCommandAdapter(RepositoryItem item, string eventName)
            : base(item, eventName)
        {
        }

        /// <summary>
        /// Handles the changes in the <see cref="Command"/> by refreshing 
        /// the <see cref="ToolStripItem.Enabled"/> property.
        /// </summary>
        protected override void OnCommandChanged(Command command)
        {
            base.OnCommandChanged(command);

            foreach (KeyValuePair<RepositoryItem, List<string>> pair in Invokers)
            {
                pair.Key.Enabled = (command.Status == CommandStatus.Enabled);
                //pair.Key. = (command.Status != CommandStatus.Unavailable);
            }
        }
    }
}
