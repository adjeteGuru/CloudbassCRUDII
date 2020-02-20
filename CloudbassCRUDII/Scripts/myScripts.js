var Role = []
//fetch Role from database

function LoadRole(element) {
    if (Has_Role.length == 0) {
//ajax function for fetch data
        $.ajax({
            type: "Get",
            url: '/Master/getHas_RoleRole',
            success: function () {
                Role = data;
                //render role
                renderRole(element)
            }
            
        })
    }

    else {
        //render role to the element
        renderRole(element);
    }
}

function renderRole(element) {
    //declare ele in element
    var $ele = $(element);

    //make it empty
    $ele.empty();

    //then added new option for sellect level   
    $ele.append($('<option/>').val('0').text('select'));

     //then loop through the role for load all the Role faced from database to the dropdown list
    $.each(Role, function (i, val){
        $ele.append($('<option/>').val(val.Id).text(val.Name));
    })

}

//fetch has_role (employee)
function LoadEmployee(roleDD) {
    $.ajax({
        type: "Get",
        url: "Master/getHas_Roles",
        data: { 'roleId': $(roleDD).val() },
        success: function (data) {
            //render has_roles (products) to appropriate dropdown
            renderEmployee($(roleDD).parents('mycontainer').find('select.employee'), data);
        },
        error: function (error) {
            console.log(error);
        }
    })
}
// function to render employees
function renderEmployee(element, data) {
    //render employee
    var $ele = $(element);
    $ele.empty;
    $ele.append($('<option/>').val('0').text('select'));
    $.each(data, function (i, val) {
        $ele.append($('<option/>').val(val.Id).text(val.fullName));
    })
}

$(document).ready(function () {
    //add button click event
    $('#add').click(function () { 

        //validation and aa job roles
        var isAllValid = true;
        if ($('#hasroleRole').val() == "0") {
            isAllValid = false;
            $('#hasroleRole').siblings('span.error').css('visibility', 'visible');
        }

        else {
            $('#hasroleRole').siblings('span.error').css('visibility', 'hidden');
        }


        //employee/product
        if ($('#employee').val() == "0") {
            isAllValid = false;
            $('#employee').siblings('span.error').css('visibility', 'visible');
        }

        else {
            $('#employee').siblings('span.error').css('visibility', 'hidden');
        }


        //totalDays
        if (!($('#totalDays').val().trim() != '' && (parseInt($('#totalDays').val()) || 0 ))) {
            isAllValid = false;
            $('#totalDays').siblings('span.error').css('visibility', 'visible');
        }

        else {
            $('#totalDays').siblings('span.error').css('visibility', 'hidden');
        }

        //rate
        if (!($('#rate').val().trim() != '' && !isNaN($('#rate').val().trim()))) {
            isAllValid = false;
            $('#rate').siblings('span.error').css('visibility', 'visible');
        }

        else {
            $('#rate').siblings('span.error').css('visibility', 'hidden');
        }

        if (isAllValid) {
            var $newRow = $('#mainrow').clone().removeAttr('id');
            $('.pc', $newRow).val($('#hasroleRole').val());
            $('.employee', $newRow).val($('#employee').val());

            //Replace add button with rempove button
            $('#add', $newRow).addClass('remove').val('Remove').removeClass('btn-success').addClass('btn-danger');

            //remove id attribute from new clone row
            $('#hasroleRole, #employee, totalDays, rate, add', $newRow).removeAttr('id');
            $('span-error', $newRow).remove();

            //append clone row
            $('#crewStaff').append($newRow);

            //clear select data
            $('#hasroleRole, ##employee,').val('0');
            $('#totalDays, #rate').val('');
            $('#crewError').empty();
        }
    })

    //remove button click event
})