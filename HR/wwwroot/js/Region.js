const EmpDepartment = document.querySelector("#Province");
const District = document.querySelector("#District");

 
$(document).ready(function () { 
    let Zipcode = $("#Zipcode");
    let Subdistrict = $("#SubDistrict");
    let District = $("#District");
    let Province = $("#Province");
    let Boss = $("#BossId");
    let EmpDepartmentId = $("#EmpDepartmentId");

    Boss.prop('disabled', true); 
    Zipcode.prop('disabled', true);
    Subdistrict.prop('disabled', true);
    District.prop('disabled', true);

    EmpDepartmentId.change(function () {
        if ($(this).val() == 0) {
            Boss.prop('disabled', true);
            Boss.val(0);
        }
        else {
            Boss.prop('disabled', false);
            $.ajax({
                url: "/api/boss/" + $(this).val(),
                method: "get",
                success: function (data) {
                    Boss.empty();
                    Boss.append($('<option>', { value: '0', text: 'Select one' }));
                    $(data).each(function (index, item) {
                        Boss.append($('<option>', { value: item.Id, text: item.empName }));
                    });
                }
            });
        }
    });

    Province.change(function () {
        if ($(this).val() == 0) {
            District.prop('disabled', true);
            District.val(0);
        }
        else {
            District.prop('disabled', false);
            $.ajax({
                url: "/api/district/" + $(this).val(),
                method: "get",
                success: function (data) {
                    District.empty();
                    District.append($('<option>', { value: '0', text: 'Select one' }));
                    $(data).each(function (index, item) {
                        District.append($('<option>', { value: item.id, text: item.districtName }));
                    });
                }
            });
        }
    });

    District.change(function () {
        if ($(this).val() == 0) {
            Subdistrict.prop('disabled', true);
            Subdistrict.val(0);
        }
        else {
            Subdistrict.prop('disabled', false);
            $.ajax({
                url: "/api/subdistrict/" + $(this).val(),
                method: "get",
                success: function (data) {
                    Subdistrict.empty();
                    Subdistrict.append($('<option>', { value: '0', text: 'Select one' }));
                    $(data).each(function (index, item) {
                        console.log(item.subdistrictName);
                        Subdistrict.append($('<option>', { value: item.id, text: item.subdistrictName }));
                    });
                }
            });
        }
    });

    Subdistrict.change(function () {
        if ($(this).val() != 0) {
            Zipcode.prop('disabled', false);
            $.ajax({
                url: "/api/zipcode/" + $(this).val(),
                method: "get",
                success: function (data) {
                    Zipcode.empty(); 
                    $(data).each(function (index, item) {
                        console.log(data);
                        Zipcode.append($('<option>', { value: item.id, text: item.zipcodeName }));
                    });
                }
            });
        }
    });

    

});