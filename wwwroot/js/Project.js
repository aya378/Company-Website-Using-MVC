function DisplayProjects() {
    var employeeId = document.getElementById("empId").value;
    $.ajax({
        url: "/worksFor/Get/" + employeeId,
        success: function (data) {
            console.log(data);
            var area = document.getElementById("Selectedproject");
            area.innerHTML = data;
        }
    });
}

function DisplayHours() {
    var projectId = document.getElementById("projId").value;
    $.ajax({
        url: "/worksFor/GetHours/" + projectId,
        success: function (data) {
            console.log(data);
            var area = document.getElementById("SelectedprojectHours");
            area.innerHTML = data;
        }
    })
}

$(".updateHourBtn").click(function () {
    var hourId = $(this).data("id");
    var newHours = $(this).prev("input[name='hours']").val();

    $.ajax({
        url: "/WorksFor/EditHours",
        method: "POST",
        data: { id: hourId, hours: newHours },
        success: function (data) {
            //if (data) {
            //    alert("Hours updated successfully!");
            //} else {
            //    alert("Failed to update hours. Please try again.");
            //}
        }
      
    });
});

