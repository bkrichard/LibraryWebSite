function ValidatePrice(oSrc, args) {
    var regex = /^[0-9]\d*(((,\d{3}){1})?(\.\d{0,2})?)$/;
    args.IsValid = regex.test(args.Value)
}