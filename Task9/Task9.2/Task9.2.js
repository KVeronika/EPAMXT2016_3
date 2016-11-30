/**
 * Created by Veronika on 11/23/2016.
 */
(function () {
    var digitPattern = /\d+\.?\d*/g,
        commonPattern = /\d+\.?\d*|[\+\-\*\/]/g,
        expressionPattern = /^[+-]?((\d+)|(\d+?\.\d+))([-+/*]((\d+)|(\d+\.\d+)))+=$/g,
        calculateBtn = document.getElementById('calculateButton').addEventListener('click', calculateExpression);

    function readLineFromInput() {
        return document.getElementById('inputString').value.split(' ').join('');
    }
    function calculateExpression() {
        var line = readLineFromInput(),
            result = 0,
            i;
        if(!line.match(expressionPattern)){
            alert('Input string is not valid');
            return;
        }
        line = line.match(commonPattern);
        if (line[0].match(digitPattern)) {
            line.splice(0, 0, '+');
        }
        for (i = 0; i < line.length; i += 2) {
            switch(line[i]){
                case '+':{
                    result += +line[i + 1];
                    break;
                }
                case '-':{
                    result -= line[i + 1];
                    break;
                }
                case '*':{
                    result *= line[i + 1];
                    break;
                }
                case '/':{
                    result /= line[i + 1];
                    break;
                }
            }
        }
        if (isNaN(result)) {
            alert('Input string is not valid')
        }
        else {
            alert(result.toFixed(2));
        }
    }
})();