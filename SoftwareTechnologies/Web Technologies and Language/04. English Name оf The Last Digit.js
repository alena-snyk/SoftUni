function solve(args){

    let lastNumber = args[0].toString();
    //console.log(lastNumber);
    lastNumber = lastNumber.substring(lastNumber.length-1);
    //console.log(lastNumber);
    lastNumber = lastNumber * 1;
    //console.log(lastNumber);
    switch (lastNumber){

        case 1:
            console.log("one");
            break;
        case 2:
            console.log("two");
            break;
        case 3:
            console.log("three");
            break;
        case 4:
            console.log("four");
            break;
        case 5:
            console.log("five");
            break;
        case 6:
            console.log("six");
            break;
        case 7:
            console.log("seven");
            break;
        case 8:
            console.log("eight");
            break;
        case 9:
            console.log("nine");
            break;
        case 0:
            console.log("zero");
            break;
    }

}
