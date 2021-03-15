function statusChange(status) {
    if (status == "cash")
        $("#customerDrp").hide();
    else
        $("#customerDrp").show();
}

function UpdateTable(itemsArray) {
    let tr = '';
    let totalQuantity = 0;
    let grandTotal = 0;
    for (let i = 0; i < itemsArray.length; i++) {
        let item = itemsArray[i];
        let trToAdd = `<tr>
                        <td>${item.id}</td>
                        <td>${item.itemName}</td>
                        <td>${item.unitRate}</td>
                        <td>${item.quantity}</td>
                        <td>${item.discount}</td>
                        <td>${item.amount}</td>
                      </tr>`;
        tr += trToAdd;
        totalQuantity = totalQuantity + item.quantity;
        grandTotal = grandTotal + item.amount;
    }
    $("#TableBody").empty().append(tr);
    //let totalQuantity = parseInt($("#TotalQuantity").val()) + obj.quantity;
    $("#TotalQuantity").val(totalQuantity);
    //let grandTotal = parseFloat($("#GrandTotal").val()) + obj.total;
    $("#GrandTotal").val(grandTotal);
    //$("#Table").show();
}