function Solve(args){
    console.log("{ "+args[0]+": \'"+args[1]+"\',"+" "+args[2]+": \'"+args[3]+"\',"+" "+args[4]+": \'"+args[5]+"\' }");
}

function assignProperties(arr) {
    let object = {};
    object[arr[0]] = arr[1];
    object[arr[2]] = arr[3];
    object[arr[4]] = arr[5];

    console.log(object);
}
assignProperties(['name', 'Pesho', 'age', '23', 'gender', 'male']);
assignProperties(['ssid', '90127461', 'status', 'admin', 'expires', '600']);