using System;
using t.MyChatkit.ModelChatkit.ModelRelatedSubcriptionMessage;
using Xamarin.Forms;

namespace t.Pages
{
    public class ConversationDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate InCommingCell { get; set; }
        public DataTemplate OutGoingCell { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return ((MessageData)item).user_id == SubcriptionJib.user_id ?  OutGoingCell : InCommingCell;
        }
    }
}