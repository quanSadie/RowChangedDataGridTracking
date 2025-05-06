namespace EditRowTrack
{
    using System.Collections.Generic;
    using System.Windows.Controls;
    using System.Windows.Interactivity;

    public class ChangeTrackingBehavior : Behavior<DataGrid>
    {
        private readonly HashSet<object> _changedItems = new HashSet<object>();

        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.Loaded += DataGrid_Loaded;
            AssociatedObject.RowEditEnding += DataGrid_RowEditEnding;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.Loaded -= DataGrid_Loaded;
            AssociatedObject.RowEditEnding -= DataGrid_RowEditEnding;
        }

        private void DataGrid_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            _changedItems.Clear();
        }

        private void DataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit && e.Row.Item != null)
            {
                _changedItems.Add(e.Row.Item);
            }
        }

        public IEnumerable<object> GetChangedItems()
        {
            return _changedItems;
        }

        public void ClearChanges()
        {
            _changedItems.Clear();
        }
    }
}
