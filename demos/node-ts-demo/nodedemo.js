const otherFile = require('./otherFile.js');
const fs = require('fs-extra');

console.log(`${otherFile.myVar} is one of the Monkeys`);

console.log(otherFile.myFunc('People who are not at 4th grade reading level by 10 years old,', 5));

fs.writeFileSync('./DeepThoughts.txt', 'Sometimes I wonder if penguins have Napoleon complex.');