 function addForm(sub,main) {
    const hr = document.createElement('hr'); // create hr tag 
     let main_div = document.getElementById(main);
     let sub_div = document.querySelectorAll(`#${sub}`);

     let index = sub_div.length; // count before add new child div => start from 1 => second element array = 1 

     const div_row_slibling = `<div id="sibling_info">
                             <div class = "row">
                                <div class="col-md-6 mb-3">
                                     <label for ="EmpSlibingName" asp-for="SlibingList[${index}].EmpSlibingName" class="form-label">Slibing's name</label>
                                      <input name ="SlibingList[${index}].EmpSlibingName" asp-for="SlibingList[${index}].EmpSlibingName" class="form-control">
                                      <span asp-validation-for="SlibingList[${index}].EmpSlibingName" class="text-danger"></span>
                                </div>

                                <div class="col-md-6 mb-3">
                                    <label for ="SlibingList[${index}].EmpSlibingSurname" asp-for="SlibingList[${index}].EmpSlibingSurname" class="form-label">Slibing's surname</label>
                                     <input name="SlibingList[${index}].EmpSlibingSurname" asp-for="SlibingList[${index}].EmpSlibingSurname" class="form-control">
                                      <span asp-validation-for="SlibingList[${index}].EmpSlibingSurname" class="text-danger"></span>
                                </div>

                        <div class = "row">
                                 <div class="col-md-4 mb-3">
                                      <label asp-for="SlibingList[${index}].EmpSlibingDob" class="form-label">Birthday</label>
                                     <input type="date"  name="SlibingList[${index}].EmpSlibingDob" asp-for="SlibingList[${index}].EmpSlibingDob" class="form-control">
                                      <span asp-validation-for="SlibingList[${index}].EmpSlibingDob" class="text-danger"></span>
                                 </div>

                                 <div class="col-md-4 mb-3">
                                     <label asp-for="SlibingList[${index}].EmpSlibingJob" class="form-label">Job</label>
                                     <input name="SlibingList[${index}].EmpSlibingJob" asp-for="SlibingList[${index}].EmpSlibingJob" class="form-control">
                                      <span asp-validation-for="SlibingList[${index}].EmpSlibingJob" class="text-danger"></span>
                                 </div>

                                 <div class="col-md-4 mb-3">
                                    <label asp-for="SlibingList[${index}].EmpSlibingTel" class="form-label">Tel</label>
                                     <input name="SlibingList[${index}].EmpSlibingTel" asp-for="SlibingList[${index}].EmpSlibingTel" class="form-control">
                                      <span asp-validation-for="SlibingList[${index}].EmpSlibingTel" class="text-danger"></span>
                                 </div>
                             </div>
                          </div>`;

     const div_row_child = `<div id="child_info">
                             <div class = "row">
                                <div class="col-md-4 mb-3">
                                     <label asp-for="ChildernList[${index}].EmpChildName" class="form-label">Child's name</label>
                                     <input name="ChildernList[${index}].EmpChildName" asp-for="ChildernList[${index}].EmpChildName" class="form-control" id="EmpChildName">
                                      <span asp-validation-for="ChildernList[${index}].EmpChildName" class="text-danger"></span>
                                </div>

                                <div class="col-md-4 mb-3">
                                     <label asp-for="ChildernList[${index}].EmpChildSurname" class="form-label">Child's surname</label>
                                     <input name="ChildernList[${index}].EmpChildSurname"  asp-for="ChildernList[${index}].EmpChildSurname" class="form-control" id="EmpChildSurname">
                                      <span asp-validation-for="ChildernList[${index}].EmpChildSurname" class="text-danger"></span>
                                </div>

                                 <div class="col-md-4 mb-3">
                                     <label asp-for="ChildernList[${index}].EmpChildDob" class="form-label">Birthday</label>
                                     <input name ="ChildernList[${index}].EmpChildDob" type="date" asp-for="ChildernList[${index}].EmpChildDob" class="form-control" id="EmpChildDob">
                                     <span asp-validation-for="ChildernList[${index}].EmpChildDob" class="text-danger"></span>
                                 </div> 
                          </div>`;

     main_div.append(hr);

     switch(main){
         case 'sibling':
             main_div.insertAdjacentHTML('beforeend', div_row_slibling);
             break;
         case 'child':
             main_div.insertAdjacentHTML('beforeend', div_row_child);
             break;
     } 


}

// start function toggle Card

const show = document.querySelectorAll('#show-card');
const hide = document.querySelectorAll('#hide-card');
const mainbar = document.querySelectorAll('#toggle-card');
const targetDiv = document.querySelectorAll('#toggleCard');
const cardRow = document.querySelectorAll('.toggleCardRow');

function toggle(index) {
    show[index].classList.toggle('visually-hidden');
    hide[index].classList.toggle('visually-hidden');
    targetDiv[index].classList.toggle('closeCard');
    cardRow[index].classList.toggle('closeCard');
}

mainbar.forEach((item, index) => {
    item.addEventListener('click', function () {
        toggle(index)
    });
});


// finish function toggle card
 