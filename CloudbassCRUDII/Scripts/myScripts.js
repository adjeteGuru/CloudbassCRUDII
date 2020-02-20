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
        if (!($('#totalDays').val().trim() != '' && (parseInt($('#totalDays').val()) || 0))) {
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
    $('#crewStaff').on('click', 'remove', function () {
        $(this).parent('tr').remove();
    });

    //save
    $('#submit').click(function () {
        var isAllValid = true;

        //valid jo
        $('#crewError').text('');

        var list = [];
        var errorItemCount = 0;
        $('#crewStaff tbody tr').each(function (index, ele) {
            if (
                $('select.employee', this).val() == "0" ||
                (parseInt($('.totalDays', this).val()) || 0) == 0 ||
                isNaN($('.rate', this).val())
            ) {

                errorItemCount++;
                $(this).addClass('error');
            } else {
                var crew = {
                    employeeId: $('select.employee', this).val(),
                    totalDays: parseInt($('.totalDays', this).val()),
                    rate: parseFloat($('.rate', this).val())
                }

                list.push(crew);
            }

        })

        if (errorItemCount > 0) {
            $('#crewError').text(errorItemCount + "invalid entry in booking list")
            isAllValid = false;
        }

        if (list.length == 0) {
            $('#crewError').text('At least 1 booking is required.');
            isAllValid = false;

        }

        if ($('dateCreated').val().trim() == '') {
            $('#dateCreated').siblings('span.error').css('visibility', 'visible');
            isAllValid = false;
        }

        else {
            $('dateCreated').siblings('span.error').css('visibility', 'hidden');
        }

        if (isAllValid) {
            var data = {
                jobRef: $('#jobRef').val().trim(),
                DateCreatedString: $('#dateCreated').val().trim(),
                Description: $('#description').va().trim(),
                Crew: list

            }

            $(this).val('Please wait...');
            $.ajax({

                type: 'POST',
                url: '/Master/save',
                data: JSON.stringify(data),
                contentType: 'application/json',
                success: function (data) {
                    if (d.status) {
                        alert('Successfully saved');
                        //here we will clear the dorm
                        list = [];
                        $('#jobRef, #dateCreated, #description').val('');
                        $('#crewStaff').empty();

                    }

                    else {
                        alert('Error');
                    }
                    $('#submit').text('save');
                },

                error: function (error) {
                    console.log(error);
                    $('#submit').text('save');
                }
            });

        }

    });

});

LoadRole($('#hasroleRole'));
