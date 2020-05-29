var AttendanceService = function () {
    var headerToken = "Bearer 8eCd-NRc5Ff9_FIaUui-38xyRY3RdYLgkMjboF6-YbxHS6mOxu27_Bn2zXYhf1QT3dt3lHQ7r0K3kN3c3jL7DLNKvYvRftd4hFpw-m1pxySp_W_ebHYZhSfI_xRmryt3SjzCi9KfyO1s9YDTj2KRLfJsvxnijdWF7dd4PuTIbAbOpONSCIiVqTvhrGGYuwTzV3EXw0FVPEdBMswp5fEGTlcRGDHbWVOVuz1R5ZnwXXgWP7lxpF2ba9G9I3jTgxTfVzedANXg6jjeGc_UwCHwypU4j_DA7f3x_X4NVPBO1d23YG5UMuptG8npdlHLEv4_x0KNhFBWGCyyHrpOHgSoUJeRif2Ad_avgn_QNRm-Bug8WjZXb841YrKYiYP6ISG_KRf9jdnh2rPXI08eF0yZpa0lmQgeNcazHw2lGiKOY1LBL5dnjV_EqJE7YY5iRUhCZjYsL7BtbfPB0e3HOS0tPL_kLtCPhBWxkzAutOY2mfI";


    var createAttendance = function (attendanceDto, done, fail) {
        $.ajax({
            url: '/api/attendances',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(attendanceDto),
            headers: {
                'Authorization': headerToken
            },
            success: done,
            error: fail
        });
    };

    var deleteAttendance = function (attendanceDto, done, fail) {
        $.ajax({
            url: '/api/attendances',
            type: 'DELETE',
            contentType: 'application/json',
            data: JSON.stringify(attendanceDto),
            headers: {
                'Authorization': headerToken
            },

            success: done,
            error: fail
        });
    };

    return {
        createAttendance: createAttendance,
        deleteAttendance: deleteAttendance
    }
}();