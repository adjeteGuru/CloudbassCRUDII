var Role = []
//fetch Role from database

function LoadRole(element) {
    if (Role.length == 0) {
            //ajax function for fetch data
        $.ajax({
            type: "GET",
            url: '/Master/getEmployeeRole',
            success: function () {
                Role = data;
                //render role
                renderRole(element);
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
    $ele.append($('<option/>').val('0').text('Select'));

     //then loop through the role for load all the Role faced from database to the dropdown list
    $.each(Role, function (i, val){
        $ele.append($('<option/>').val(val.roleId).text(val.Name));
    })
}


//fetch employees
function LoadEmployee(roleDD) {
    $.ajax({
        type: "GET",
        url: "Master/getEmployees",
        data: { 'roleID': $(roleDD).val() },
        success: function (data) {
            //render employees to appropriate dropdown
            renderEmployee($(roleDD).parents('.mycontainer').find('select.employee'), data);
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
    $ele.append($('<option/>').val('0').text('Select'));
    $.each(data, function (i, val) {
        $ele.append($('<option/>').val(val.Id).text(val.fullName));
    })
}



$(document).ready(function () {
    //add button click event
    $('#add').click(function () {

        //validation and add job roles
        var isAllValid = true;
        if ($('#employeeRole').val() == "0") {
            isAllValid = false;
            $('#employeeRole').siblings('span.error').css('visibility', 'visible');
        }

        else {
            $('#employeeRole').siblings('span.error').css('visibility', 'hidden');
        }


        //employee/
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
            $('.er', $newRow).val($('#employeeRole').val());
            $('.employee', $newRow).val($('#employee').val());

            //Replace add button with rempove button
            $('#add', $newRow).addClass('remove').val('Remove').removeClass('btn-success').addClass('btn-danger');

            //remove id attribute from new clone row
            $('#employeeRole,#employee,#totalDays,#rate,#add', $newRow).removeAttr('id');
            $('span-error', $newRow).remove();

            //append clone row
            $('#crewStaff').append($newRow);

            //clear select data
            $('#employeeRole,#employee,').val('0');
            $('#totalDays,#rate').val('');
            $('#crewError').empty();
        }
    })

    //remove button click event
    $('#crewStaff').on('click', '.remove', function () {
        $(this).parent('tr').remove();
    });

    //save
    $('#submit').click(function () {
        var isAllValid = true;

        //validate crew members
        $('#crewError').text('');

        var list = [];
        var errorItemCount = 0;
        $('#crewStaff tbody tr').each(function (index, ele) {
            if (
                $('select.employee', this).val() == "0" ||
                (parseInt($('.totalDays', this).val()) || 0) == 0 ||
                $('.rate', this).val() == "" ||
                isNaN($('.rate', this).val())
                ) {

                errorItemCount++;
                $(this).addClass('error');
            } else {
                var crew = {
                    Id: $('select.employee', this).val(),
                    totalDays: parseInt($('.totalDays', this).val()),
                    rate: parseFloat($('.rate', this).val())
                }

                list.push(crew);
            }

        })

        if (errorItemCount > 0) {
            $('#crewError').text(errorItemCount + "invalid entry in booking list.")
            isAllValid = false;
        }

        if (list.length == 0) {
            $('#crewError').text('At least 1 booking is required.');
            isAllValid = false;

        }

        if ($('#jobRef').val().trim() == '') {
            $('#jobRef').siblings('span.error').css('visibility', 'visible');
            isAllValid = false;
        }

        else {
            $('#jobRef').siblings('span.error').css('visibility', 'hidden');
        }

        if ($('#dateCreated').val().trim() == '') {
            $('#dateCreated').siblings('span.error').css('visibility', 'visible');
            isAllValid = false;
        }

        else {
            $('#dateCreated').siblings('span.error').css('visibility', 'hidden');
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
                    if (data.status) {
                        alert('Successfully saved');
                        //here we will clear the form
                        list = [];
                        $('#jobRef,#dateCreated,#description').val('');
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

LoadRole($('#employeeRole'));
