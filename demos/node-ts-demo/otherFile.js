console.log('Hey Hey world! We\'re the ...');


let myVar = 'Mark';
function myFunc(str, myInt) {
  return `${str} are ${myInt} times more likely to drop out of school.`
}

// module.exports = myVar;
exports.myVar = myVar;
exports.myFunc = myFunc;

