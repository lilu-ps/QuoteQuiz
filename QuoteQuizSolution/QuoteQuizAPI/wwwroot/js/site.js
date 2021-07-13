$(document).ready(function () {
    var radios = document.getElementsByName("SettingSwitcher");
    for (var i = 0; i < radios.length; i++) {
        radios[i].addEventListener('change', function () {
            var radioButtonValue = $('input[name=SettingSwitcher]:checked', '#SettingSwitcherGroup').val();
            console.log(radioButtonValue);
            var userId = $("#hdnUserId").val();
            console.log(userId);
            $.ajax({
                type: 'GET',
                url: '/Quiz/ChangeMode',
                data: { newModeId: radioButtonValue, userId: userId},
                success: function (a) {
                    $('#ModeChangeRes').html("Mode Changed!");
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert(errorThrown)
                    $('#ModeChangeRes').html("Mode Change error!");
                }
            });
        });
    }

});



function modifyUser(user) {
    var email = $('#mod-userName').val();
    var firstName = $('#mod-firstName').val();
    var lastName = $('#mod-lastName').val();
    var password = $('#mod-password').val();

    $.ajax({
        type: 'GET',
        url: '/User/ModifyUser',
        data: { userId: user, email, firstName: firstName, lastName: lastName, password: password},
        success: function (a) {
            $('#QuizResultDiv').html("");
            $('#quiz-view').html(a);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert(errorThrown)
        }
    });
}

function goToUserManagement(user) {
    $.ajax({
        type: 'GET',
        url: '/User/UserManagement',
        data: { userId: user},
        success: function (a) {
            $('#QuizResultDiv').html("");
            $('#quiz-view').html(a);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert(errorThrown)
        }
    });
}
function myfunction(user, quote, answer) {
    $.ajax({
        type: 'GET',
        url: '/Quiz/Index',
        data: { user: user, Quote: quote, chosenAnswerId: answer },
        success: function (a) {
            $('#QuizResultDiv').html(a);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert(errorThrown)
        }
    });

}


function goToSettings(userId) {
    $.ajax({
        type: 'GET',
        url: '/Quiz/GetModes',
            data: { userId: userId},
        success: function (a) {
            $('#QuizResultDiv').html("");
            $('#quiz-view').html(a);            
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert(errorThrown)
        }
    });
}

function IsAnswerCorrect() {
    var checkBox = document.getElementById("isCorrect");
    if (checkBox.checked == true) {
    } else {
        document.getElementById("wantMultiple").checked = true;
    }
}

function wantMultiple() {
    var checkBox = document.getElementById("wantMultiple");
    if (checkBox.checked == true) {
        document.getElementById("choice1").disabled = false;
        document.getElementById("choice2").disabled = false;
        document.getElementById("isCorrect").disabled = true;
        document.getElementById("isCorrect").checked = true;

    } else {
        document.getElementById("isCorrect").disabled = false;
        document.getElementById("choice1").disabled = true;
        document.getElementById("choice2").disabled = true;
    }
}


function reviewMyHistory(userId) {
    $.ajax({
        type: 'GET',
        url: '/User/getUserGames',
        data: { id: userId},
        success: function (a) {
            $('#QuizResultDiv').html("");
            $('#quiz-view').html(a);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert(errorThrown)
        }
    });
}
function reviewOtherUsers(userId) {
    $.ajax({
        type: 'GET',
        url: '/User/ReviewOthers',
        data: { userId: userId },
        success: function (a) {
            $('#QuizResultDiv').html("");
            $('#quiz-view').html(a);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert(errorThrown)
        }
    });
}

function binaryAnswer(user, quote, givenChoice, answer) {
    $.ajax({
        type: 'GET',
        url: '/Quiz/BinaryQuiz',
        data: { user: user, Quote: quote, givenChoice: givenChoice, agreed : answer },
        success: function (a) {
            $('#QuizResultDiv').html(a);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert(errorThrown)
        }
    });
}

function getNextQuote(userId) {
    $.ajax({
        type: 'GET',
        url: '/Quote/TabIndex',
        data: { userId: userId},
        success: function (a) {
            $('#QuizResultDiv').html("");
            $('#quiz-view').html(a);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert(errorThrown)
        }
    });
}