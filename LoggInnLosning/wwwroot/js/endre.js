﻿////$(function () {
////    // hent kunden med kunde-id fra url og vis denne i skjemaet

////    const id = window.location.search.substring(1);
////    const url = "Kunde/HentEn?" + id;
////    $.get(url, function (kunde) {
////        $("#id").val(kunde.id); // må ha med id inn skjemaet, hidden i html
////        $("#fornavn").val(kunde.fornavn);
////        $("#etternavn").val(kunde.etternavn);
////        $("#adresse").val(kunde.adresse);
////        $("#postnr").val(kunde.postnr);
////        $("#poststed").val(kunde.poststed);
////    });
////});

////function validerOgEndreKunde() {
////    const fornavnOK = validerFornavn($("#fornavn").val());
////    const etternavnOK = validerEtternavn($("#etternavn").val());
////    const adresseOK = validerAdresse($("#adresse").val());
////    const postnrOK = validerPostnr($("#postnr").val());
////    const poststedOK = validerPoststed($("#poststed").val());
////    if (fornavnOK && etternavnOK && adresseOK && postnrOK && poststedOK) {
////        endreKunde();
////    }
////}

////function endreKunde() {
////    const kunde = {
////        id: $("#id").val(), // må ha med denne som ikke har blitt endret for å vite hvilken kunde som skal endres
////        fornavn: $("#fornavn").val(),
////        etternavn: $("#etternavn").val(),
////        adresse: $("#adresse").val(),
////        postnr: $("#postnr").val(),
////        poststed: $("#poststed").val()
////    };
////    $.post("Kunde/Endre", kunde, function (OK) {
////        window.location.href = 'index.html';
////        //if (OK) {
////        //    window.location.href = 'index.html';
////        //}
////        //else {
////        //    $("#feil").html("Feil i db - prøv igjen senere");
////        //}
////        if (feil.status == 401) {  // ikke logget inn, redirect til loggInn.html
////            window.location.href = 'loggInn.html';
////        }
////        else {
////            $("#feil").html("Feil på server - prøv igjen senere");
////        }
////    });
////}

$(function () {
    const id = window.location.search.substring(1);
    const url = "Kunde/HentEn?" + id;
    $.get(url, function (kunde) {
        $("#id").val(kunde.id);
        $("#fornavn").val(kunde.fornavn);
        $("#etternavn").val(kunde.etternavn);
        $("#adresse").val(kunde.adresse);
        $("#postnr").val(kunde.postnr);
        $("#poststed").val(kunde.poststed);
    });
    console.log(kunde);
});

function validerOgEndreKunde() {
    const fornavnOK = validerFornavn($("#fornavn").val());
    const etternavnOK = validerEtternavn($("#etternavn").val());
    const adresseOK = validerAdresse($("#adresse").val());
    const postnrOK = validerPostnr($("#postnr").val());
    const poststedOK = validerPoststed($("#poststed").val());
    if (fornavnOK && etternavnOK && adresseOK && postnrOK && poststedOK) {
        endreKunde();
    }
}

function endreKunde() {
    const kunde = {
        id: $("#id").val(),
        fornavn: $("#fornavn").val(),
        etternavn: $("#etternavn").val(),
        adresse: $("#adresse").val(),
        postnr: $("#postnr").val(),
        poststed: $("#poststed").val()
    };
    console.log(kunde);
    $.post("Kunde/Endre", kunde, function () {
        window.location.href = 'index.html';
    })
        .fail(function (feil) {
            if (feil.status == 401) {  // ikke logget inn, redirect til loggInn.html
                window.location.href = 'loggInn.html';
            }
            else {
                $("#feil").html("Feil på server - prøv igjen senere");
            }
        });
}