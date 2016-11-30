/**
 * Created by Veronika on 11/22/2016.
 */
(function () {
    var separators = ['.', ' ', '?', '\t', ',', ':', '!', ';'],
        symbolsForDelete = [],
        deleteBtn = document.getElementById('deleteButton').addEventListener('click', deleteSymbols);

    function readLineFromInput() {
        var textLine = document.getElementById('inputString').value + ' ';
        return textLine;
    }

    function getWordsFromString(textLine) {
        var i = 0,
            arrayOfWords = [],
            lastIndexOfSeparator = 0;
        for (i; i < textLine.length; i++) {
            if (separators.indexOf(textLine[i]) > -1) {
                arrayOfWords.push(textLine.slice(lastIndexOfSeparator, i));
                lastIndexOfSeparator = i + 1;
            }
        }
        return arrayOfWords;
    }

    function deleteSymbols() {
        var i, j,
            textLine = readLineFromInput(),
            arrayOfWords = getWordsFromString(textLine),
            temp = [];
        for(i = 0; i < arrayOfWords.length; i++){
            var letters = arrayOfWords[i].split('');
            for(j = 0; j < letters.length; j++){
                if(letters.indexOf(letters[j], j+1) >=0){
                    temp.push(letters[j]);
                }
            }
        }
        symbolsForDelete = temp;

        for(i = 0; i < symbolsForDelete.length; i++){
            replaceSymbol(symbolsForDelete[i]);
        }
        alert(textLine);

        function replaceSymbol(char) {
            var i;
            for(i = 0; i < textLine.length; i++){
                textLine = textLine.replace(char, '');
            }
        }
    }
})();

