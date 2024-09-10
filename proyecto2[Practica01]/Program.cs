using proyecto2_Practica01_.Data;
using proyecto2_Practica01_.Domain;
using proyecto2_Practica01_.Services;
using proyecto2_Practica01_.Utils;
using System.Diagnostics;

ItemManager itemM = new ItemManager();
/*
//Agregar un artículo:
var newItem = new Item
{
    Name = "Botella de jugo",
    UnitPrice = 950.00
};
bool itemSaved = itemM.SaveItem(newItem);
Console.WriteLine($"Artículo añadido:" +
                  $"\nNombre: {newItem.Name} - Precio: ${newItem.UnitPrice:F2}");

//Lista de artículos:
Console.WriteLine("Lista de artículos:");
var itemList = itemM.GetItems();
foreach (var i in itemList)
{
    Console.WriteLine($"ID: {i.Id} - Nombre: {i.Name} - Precio: ${i.UnitPrice:F2}");
}

//Artículo seleccionado con ID = 3:
var itemById = itemM.GetItemById(3);
if(itemById != null)
{
    Console.WriteLine("Artículo seleccionado:"+
                     $"\nID: {itemById.Id} - Nombre: {itemById.Name} - Precio: ${itemById.UnitPrice:F2}");
}
else
{
    Console.WriteLine("No existe ningún artículo con el ID seleccionado.");
}

//Eliminar un artículo con ID = 50:
if (itemM.DeleteItem(50))
{
    Console.WriteLine("Artículo eliminado con éxito.");
}

*/

BillManager billM = new BillManager();

//Agregar una factura:
var item1 = itemM.GetItemById(1);
var item2 = itemM.GetItemById(3);

var newBill = new Bill
{
    Date = DateTime.Now,
    Client = "Manuel Cabrera"
};
newBill.AddDetail(new BillDetail
{
    Item = item1, Amount = 2, Price = item1.UnitPrice
});
newBill.AddDetail(new BillDetail
{
    Item = item2, Amount = 1, Price = item2.UnitPrice
});
bool billSaved = billM.SaveBill(newBill);
if(billSaved)
{
    Console.WriteLine($"Factura añadida:" +
                  $"\nFecha: {newBill.Date} - Cliente: ${newBill.Client}");
    var savedBill = billM.GetBillById(newBill.Id);
    if (savedBill != null)
    {
        foreach (var detail in savedBill.GetDetails())
        {
            Console.WriteLine($"Artículo: - {detail.Item.Name} - Cantidad: {detail.Amount} - Precio unitario: ${detail.Item.UnitPrice:F2} - SubTotal: {detail.SubTotal():F2}" +
                $"\nTotal: ${newBill.Total()}");
        }
    }
}
else
{
    Console.WriteLine("No se pudo añadir la factura.");
}