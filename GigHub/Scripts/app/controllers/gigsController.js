var GigsController = function (attendanceService) {

    var button;
    var attendanceDto;

    var init = function(container) {

        $(container).on("click", ".js-toggle-attendance", toggleAttendance);

    };

    var toggleAttendance = function(e) {
        button = $(e.target);

        attendanceDto = {
            GigId: button.attr('data-gig-id')
        };

        if (button.hasClass('btn-default'))
            attendanceService.createAttendance(attendanceDto, done, fail);
        else
            attendanceService.deleteAttendance(attendanceDto, done, fail);

    };


    var fail = function(error) {
        alert(error);
    };

    var done = function () {

        var text = (button.text() === "Going") ? "Going" : "Going?";
        button.toggleClass("btn-info").toggleClass("btn-default").text(text);
    };

    return {
        init: init
    };

}(AttendanceService);