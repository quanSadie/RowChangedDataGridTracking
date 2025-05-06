# RowChangedDataGridTracking
<b>Row changed tracking for wpf datagrid</b>

This repo aims to track the records in datagrid which were edited by the user.
Can use to update by record instead of whole table.

**Usage**:
```
 <DataGrid ...>

     <i:Interaction.Behaviors>
         <local:ChangeTrackingBehavior x:Name="RowChangeTracker"/>
     </i:Interaction.Behaviors>
      ...
 </DataGrid>
```

In code behind / View model:
```
foreach (var changedItem in RowChangeTracker.GetChangedItems())
{
    ...
}
//RowChangeTracker.ClearChanges();
```
