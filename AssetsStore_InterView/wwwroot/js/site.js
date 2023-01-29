

$('body').on('click', '.remove', function () {
    debugger;
    $(this).parentsUntil('tbody').remove();
    var new_Attribute_no = parseInt($('#total_Attribute').val()) - 1;
    $('#total_Attribute').val(new_Attribute_no);
    reOrdring();
})

$('body').on('click', '.add', function () {
    debugger;
    var new_Attribute_no = parseInt($('#total_Attribute').val()) + 1;
    var new_input = "<tr class='AttributeRow'><td><input  name='Attributes[" + new_Attribute_no + "].Name' class='form-control valid' type ='text' required></td><td><input name='Attributes[" + new_Attribute_no + "].Description' class='form-control'  required></td><td> <a class='btn btn-danger remove' id='remove'> Delete </a></td ></tr>";

    $('.table tbody').append(new_input);
    $('#total_Attribute').val(new_Attribute_no);
})

function reOrdring() {
    $("tr.AttributeRow").each(function (index, row) {
        debugger;
        var RowChildernCollection = row.children;
        var length = Object.keys(RowChildernCollection).length;
        if (length === 0) // no Attribute Added
            return;
        if (length === 4) // ReOrder Attribute Entered befor (Editing)
        {
            RowChildernCollection[0].setAttribute('name', 'Attributes[' + index + '].ID');
            RowChildernCollection[1].children[0].setAttribute('name', 'Attributes[' + index + '].Name');
            RowChildernCollection[2].children[0].setAttribute('name', 'Attributes[' + index + '].Description');
        }
        else //  ReOrder Attribute Added now
        {
            RowChildernCollection[0].children[0].setAttribute('name', 'Attributes[' + index + '].Name');
            RowChildernCollection[1].children[0].setAttribute('name', 'Attributes[' + index + '].Description');
        }


    })
}




 