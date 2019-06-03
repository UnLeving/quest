
    $(document).ready(function () {
        $("#aClicked").click(function () {
            $("#OpenDialog").load('/Account/Login/');
            $("#OpenDialog").modal('show');
        });
    });
