/*!
* DevExtreme (dx.messages.it.js)
* Version: 22.1.3
* Build date: Mon Jun 13 2022
*
* Copyright (c) 2012 - 2022 Developer Express Inc. ALL RIGHTS RESERVED
* Read about DevExtreme licensing here: https://js.devexpress.com/Licensing/
*/
"use strict";

! function(root, factory) {
    if ("function" === typeof define && define.amd) {
        define((function(require) {
            factory(require("devextreme/localization"))
        }))
    } else if ("object" === typeof module && module.exports) {
        factory(require("devextreme/localization"))
    } else {
        factory(DevExpress.localization)
    }
}(0, (function(localization) {
    localization.loadMessages({
        it: {
            Yes: "S\xec",
            No: "No",
            Cancel: "Annulla",
            Clear: "Cancella",
            Done: "Fatto",
            Loading: "Caricamento...",
            Select: "Seleziona...",
            Search: "Cerca",
            Back: "Indietro",
            OK: "OK",
            "dxCollectionWidget-noDataText": "Nessun dato da mostrare",
            "dxDropDownEditor-selectLabel": "Seleziona",
            "validation-required": "Richiesto",
            "validation-required-formatted": "{0} \xe8 richiesto",
            "validation-numeric": "Il valore deve essere numerico",
            "validation-numeric-formatted": "{0} deve essere numerico",
            "validation-range": "Il valore non \xe8 compreso nell'intervallo",
            "validation-range-formatted": "{0} non \xe8 compreso nell'intervallo",
            "validation-stringLength": "Lunghezza del valore errata",
            "validation-stringLength-formatted": "La lunghezza di {0} \xe8 errata",
            "validation-custom": "Il valore non \xe8 corretto",
            "validation-custom-formatted": "{0} non \xe8 corretto",
            "validation-async": "Il valore non \xe8 corretto",
            "validation-async-formatted": "{0} non \xe8 corretto",
            "validation-compare": "I valori non corrispondono",
            "validation-compare-formatted": "{0} non corrisponde",
            "validation-pattern": "Il valore non \xe8 corretto",
            "validation-pattern-formatted": "{0} non \xe8 corretto",
            "validation-email": "L'Email non \xe8 corretta",
            "validation-email-formatted": "{0} non \xe8 una email corretta",
            "validation-mask": "Il valore non \xe8 corretto",
            "dxLookup-searchPlaceholder": "Lunghezza minima: {0}",
            "dxList-pullingDownText": "Trascina in basso per aggiornare...",
            "dxList-pulledDownText": "Rilascia per aggiornare...",
            "dxList-refreshingText": "Aggiornamento...",
            "dxList-pageLoadingText": "Caricamento...",
            "dxList-nextButtonText": "Carica altri risultati",
            "dxList-selectAll": "Seleziona tutti",
            "dxListEditDecorator-delete": "Elimina",
            "dxListEditDecorator-more": "Ancora",
            "dxScrollView-pullingDownText": "Trascina in basso per aggiornare...",
            "dxScrollView-pulledDownText": "Rilascia per aggiornare...",
            "dxScrollView-refreshingText": "Aggiornamento...",
            "dxScrollView-reachBottomText": "Caricamento...",
            "dxDateBox-simulatedDataPickerTitleTime": "Seleziona orario",
            "dxDateBox-simulatedDataPickerTitleDate": "Seleziona data",
            "dxDateBox-simulatedDataPickerTitleDateTime": "Seleziona data e ora",
            "dxDateBox-validation-datetime": "Il valore deve essere una data o un orario",
            "dxFileUploader-selectFile": "Seleziona file",
            "dxFileUploader-dropFile": "o trascina il file qui",
            "dxFileUploader-bytes": "bytes",
            "dxFileUploader-kb": "kb",
            "dxFileUploader-Mb": "Mb",
            "dxFileUploader-Gb": "Gb",
            "dxFileUploader-upload": "Carica",
            "dxFileUploader-uploaded": "Caricato",
            "dxFileUploader-readyToUpload": "Pronto per caricare",
            "dxFileUploader-uploadAbortedMessage": "TODO",
            "dxFileUploader-uploadFailedMessage": "Caricamento fallito",
            "dxFileUploader-invalidFileExtension": "TODO",
            "dxFileUploader-invalidMaxFileSize": "TODO",
            "dxFileUploader-invalidMinFileSize": "TODO",
            "dxRangeSlider-ariaFrom": "Da",
            "dxRangeSlider-ariaTill": "fino a",
            "dxSwitch-switchedOnText": "ON",
            "dxSwitch-switchedOffText": "OFF",
            "dxForm-optionalMark": "opzionale",
            "dxForm-requiredMessage": "{0} \xe8 richiesto",
            "dxNumberBox-invalidValueMessage": "Il valore deve essere numerico",
            "dxNumberBox-noDataText": "Nessun dato",
            "dxDataGrid-columnChooserTitle": "Selezione colonne",
            "dxDataGrid-columnChooserEmptyText": "Trascina qui una colonna per nasconderla",
            "dxDataGrid-groupContinuesMessage": "Pagina successiva",
            "dxDataGrid-groupContinuedMessage": "Continua da pagina precedente",
            "dxDataGrid-groupHeaderText": "Raggruppa per questa colonna",
            "dxDataGrid-ungroupHeaderText": "Separa",
            "dxDataGrid-ungroupAllText": "Separa tutti",
            "dxDataGrid-editingEditRow": "Modifica",
            "dxDataGrid-editingSaveRowChanges": "Salva",
            "dxDataGrid-editingCancelRowChanges": "Annulla",
            "dxDataGrid-editingDeleteRow": "Elimina",
            "dxDataGrid-editingUndeleteRow": "Ripristina",
            "dxDataGrid-editingConfirmDeleteMessage": "Sei certo di voler eliminare questo record?",
            "dxDataGrid-validationCancelChanges": "Annulla le modifiche",
            "dxDataGrid-groupPanelEmptyText": "Trascina qui l'intestazione di una colonna per raggrupparla",
            "dxDataGrid-noDataText": "Nessun dato",
            "dxDataGrid-searchPanelPlaceholder": "Cerca...",
            "dxDataGrid-filterRowShowAllText": "(Tutti)",
            "dxDataGrid-filterRowResetOperationText": "Annulla",
            "dxDataGrid-filterRowOperationEquals": "Uguale",
            "dxDataGrid-filterRowOperationNotEquals": "Diverso",
            "dxDataGrid-filterRowOperationLess": "Minore di",
            "dxDataGrid-filterRowOperationLessOrEquals": "Minore o uguale a",
            "dxDataGrid-filterRowOperationGreater": "Maggiore di",
            "dxDataGrid-filterRowOperationGreaterOrEquals": "Maggiore o uguale a",
            "dxDataGrid-filterRowOperationStartsWith": "Inizia con",
            "dxDataGrid-filterRowOperationContains": "Contiene",
            "dxDataGrid-filterRowOperationNotContains": "Non contiene",
            "dxDataGrid-filterRowOperationEndsWith": "Termina con",
            "dxDataGrid-filterRowOperationBetween": "Compreso",
            "dxDataGrid-filterRowOperationBetweenStartText": "Inizio",
            "dxDataGrid-filterRowOperationBetweenEndText": "Fine",
            "dxDataGrid-applyFilterText": "Applica filtro",
            "dxDataGrid-trueText": "vero",
            "dxDataGrid-falseText": "falso",
            "dxDataGrid-sortingAscendingText": "Ordinamento ascendente",
            "dxDataGrid-sortingDescendingText": "Ordinamento discendente",
            "dxDataGrid-sortingClearText": "Annulla ordinamento",
            "dxDataGrid-editingSaveAllChanges": "Salva le modifiche",
            "dxDataGrid-editingCancelAllChanges": "Annulla le modifiche",
            "dxDataGrid-editingAddRow": "Aggiungi una riga",
            "dxDataGrid-summaryMin": "Min: {0}",
            "dxDataGrid-summaryMinOtherColumn": "Min di {1} \xe8 {0}",
            "dxDataGrid-summaryMax": "Max: {0}",
            "dxDataGrid-summaryMaxOtherColumn": "Max di {1} \xe8 {0}",
            "dxDataGrid-summaryAvg": "Media: {0}",
            "dxDataGrid-summaryAvgOtherColumn": "Media di {1} \xe8 {0}",
            "dxDataGrid-summarySum": "Somma: {0}",
            "dxDataGrid-summarySumOtherColumn": "Somma di {1} \xe8 {0}",
            "dxDataGrid-summaryCount": "Elementi: {0}",
            "dxDataGrid-columnFixingFix": "Blocca",
            "dxDataGrid-columnFixingUnfix": "Sblocca",
            "dxDataGrid-columnFixingLeftPosition": "Alla sinistra",
            "dxDataGrid-columnFixingRightPosition": "Alla destra",
            "dxDataGrid-exportTo": "Esporta",
            "dxDataGrid-exportToExcel": "Esporta in Excel",
            "dxDataGrid-exporting": "Esportare...",
            "dxDataGrid-excelFormat": "File Excel",
            "dxDataGrid-selectedRows": "Righe selezionate",
            "dxDataGrid-exportSelectedRows": "Esporta le righe selezionate",
            "dxDataGrid-exportAll": "Esporta tutti i dati",
            "dxDataGrid-headerFilterEmptyValue": "(vuoto)",
            "dxDataGrid-headerFilterOK": "OK",
            "dxDataGrid-headerFilterCancel": "Annulla",
            "dxDataGrid-ariaColumn": "Colonna",
            "dxDataGrid-ariaValue": "Valore",
            "dxDataGrid-ariaFilterCell": "Filtra cella",
            "dxDataGrid-ariaCollapse": "Chiudi",
            "dxDataGrid-ariaExpand": "Espandi",
            "dxDataGrid-ariaDataGrid": "Griglia dati",
            "dxDataGrid-ariaSearchInGrid": "Cerca nella griglia",
            "dxDataGrid-ariaSelectAll": "Seleziona tutti",
            "dxDataGrid-ariaSelectRow": "Seleziona riga",
            "dxDataGrid-filterBuilderPopupTitle": "Composizione filtro",
            "dxDataGrid-filterPanelCreateFilter": "Nuovo filtro",
            "dxDataGrid-filterPanelClearFilter": "Cancella",
            "dxDataGrid-filterPanelFilterEnabledHint": "Attiva il filtro",
            "dxTreeList-ariaTreeList": "Albero",
            "dxTreeList-editingAddRowToNode": "Aggiungi",
            "dxPager-infoText": "Pagina {0} di {1} ({2} elementi)",
            "dxPager-pagesCountText": "di",
            "dxPager-pageSizesAllText": "Tutti",
            "dxPivotGrid-grandTotal": "Totale",
            "dxPivotGrid-total": "{0} Totale",
            "dxPivotGrid-fieldChooserTitle": "Selezione campi",
            "dxPivotGrid-showFieldChooser": "Mostra selezione campi",
            "dxPivotGrid-expandAll": "Espandi tutto",
            "dxPivotGrid-collapseAll": "Comprimi tutto",
            "dxPivotGrid-sortColumnBySummary": 'Ordina "{0}" per questa colonna',
            "dxPivotGrid-sortRowBySummary": 'Ordina "{0}" per questa riga',
            "dxPivotGrid-removeAllSorting": "Rimuovi ordinamenti",
            "dxPivotGrid-dataNotAvailable": "N/A",
            "dxPivotGrid-rowFields": "Campi riga",
            "dxPivotGrid-columnFields": "Campi colonna",
            "dxPivotGrid-dataFields": "Campi dati",
            "dxPivotGrid-filterFields": "Campi filtro",
            "dxPivotGrid-allFields": "Tutti i campi",
            "dxPivotGrid-columnFieldArea": "Trascina qui i campi colonna",
            "dxPivotGrid-dataFieldArea": "Trascina qui i campi dati",
            "dxPivotGrid-rowFieldArea": "Trascina qui i campi riga",
            "dxPivotGrid-filterFieldArea": "Trascina qui i campi filtro",
            "dxScheduler-editorLabelTitle": "Oggetto",
            "dxScheduler-editorLabelStartDate": "Data inizio",
            "dxScheduler-editorLabelEndDate": "Data fine",
            "dxScheduler-editorLabelDescription": "Descrizione",
            "dxScheduler-editorLabelRecurrence": "Ripeti",
            "dxScheduler-openAppointment": "Apri appuntamento",
            "dxScheduler-recurrenceNever": "Mai",
            "dxScheduler-recurrenceMinutely": "Minutely",
            "dxScheduler-recurrenceHourly": "Hourly",
            "dxScheduler-recurrenceDaily": "Giornaliero",
            "dxScheduler-recurrenceWeekly": "Settimanale",
            "dxScheduler-recurrenceMonthly": "Mensile",
            "dxScheduler-recurrenceYearly": "Annuale",
            "dxScheduler-recurrenceRepeatEvery": "Ogni",
            "dxScheduler-recurrenceRepeatOn": "Repeat On",
            "dxScheduler-recurrenceEnd": "Termina ripetizione",
            "dxScheduler-recurrenceAfter": "Dopo",
            "dxScheduler-recurrenceOn": "Di",
            "dxScheduler-recurrenceRepeatMinutely": "minute(s)",
            "dxScheduler-recurrenceRepeatHourly": "hour(s)",
            "dxScheduler-recurrenceRepeatDaily": "giorno(i)",
            "dxScheduler-recurrenceRepeatWeekly": "settimana(e)",
            "dxScheduler-recurrenceRepeatMonthly": "mese(i)",
            "dxScheduler-recurrenceRepeatYearly": "anno(i)",
            "dxScheduler-switcherDay": "Giorno",
            "dxScheduler-switcherWeek": "Settimana",
            "dxScheduler-switcherWorkWeek": "Settimana lavorativa",
            "dxScheduler-switcherMonth": "Mese",
            "dxScheduler-switcherAgenda": "Agenda",
            "dxScheduler-switcherTimelineDay": "Cronologia giornaliera",
            "dxScheduler-switcherTimelineWeek": "Cronologia settimanale",
            "dxScheduler-switcherTimelineWorkWeek": "Cronologia settimana lavorativa",
            "dxScheduler-switcherTimelineMonth": "Cronologia mensile",
            "dxScheduler-recurrenceRepeatOnDate": "alla data",
            "dxScheduler-recurrenceRepeatCount": "occorrenza(e)",
            "dxScheduler-allDay": "Tutto il giorno",
            "dxScheduler-confirmRecurrenceEditMessage": "Vuoi modificare solo questo appuntamento o tutte le sue ricorrenze?",
            "dxScheduler-confirmRecurrenceDeleteMessage": "Vuoi eliminare solo questo appuntamento o tutte le sue ricorrenze?",
            "dxScheduler-confirmRecurrenceEditSeries": "Modifica serie",
            "dxScheduler-confirmRecurrenceDeleteSeries": "Elimina serie",
            "dxScheduler-confirmRecurrenceEditOccurrence": "Modifica appuntamento",
            "dxScheduler-confirmRecurrenceDeleteOccurrence": "Elimina appuntamento",
            "dxScheduler-noTimezoneTitle": "Nessun fuso orario",
            "dxScheduler-moreAppointments": "{0} ancora",
            "dxCalendar-todayButtonText": "Oggi",
            "dxCalendar-ariaWidgetName": "Calendario",
            "dxColorView-ariaRed": "Rosso",
            "dxColorView-ariaGreen": "Verde",
            "dxColorView-ariaBlue": "Blu",
            "dxColorView-ariaAlpha": "Trasparenza",
            "dxColorView-ariaHex": "Colore",
            "dxTagBox-selected": "{0} selezionati",
            "dxTagBox-allSelected": "Tutti selezionati ({0})",
            "dxTagBox-moreSelected": "{0} ancora",
            "vizExport-printingButtonText": "Stampa",
            "vizExport-titleMenuText": "Esportazione/Stampa",
            "vizExport-exportButtonText": "{0} file",
            "dxFilterBuilder-and": "E",
            "dxFilterBuilder-or": "O",
            "dxFilterBuilder-notAnd": "E non",
            "dxFilterBuilder-notOr": "O non",
            "dxFilterBuilder-addCondition": "Aggiungi condizione",
            "dxFilterBuilder-addGroup": "Aggiungi gruppo",
            "dxFilterBuilder-enterValueText": "<inserire un valore>",
            "dxFilterBuilder-filterOperationEquals": "Uguale a",
            "dxFilterBuilder-filterOperationNotEquals": "Diverso da",
            "dxFilterBuilder-filterOperationLess": "Minore di",
            "dxFilterBuilder-filterOperationLessOrEquals": "Minore o uguale a",
            "dxFilterBuilder-filterOperationGreater": "Maggiore di",
            "dxFilterBuilder-filterOperationGreaterOrEquals": "Maggiore o uguale a",
            "dxFilterBuilder-filterOperationStartsWith": "Inizia con",
            "dxFilterBuilder-filterOperationContains": "Contiene",
            "dxFilterBuilder-filterOperationNotContains": "Non contiene",
            "dxFilterBuilder-filterOperationEndsWith": "Termina con",
            "dxFilterBuilder-filterOperationIsBlank": "\xc8 vuoto",
            "dxFilterBuilder-filterOperationIsNotBlank": "Non \xe8 vuoto",
            "dxFilterBuilder-filterOperationBetween": "Compreso",
            "dxFilterBuilder-filterOperationAnyOf": "Include",
            "dxFilterBuilder-filterOperationNoneOf": "Non include",
            "dxHtmlEditor-dialogColorCaption": "Cambia il colore del testo",
            "dxHtmlEditor-dialogBackgroundCaption": "Cambia il colore di sfondo",
            "dxHtmlEditor-dialogLinkCaption": "Aggiungi link",
            "dxHtmlEditor-dialogLinkUrlField": "URL",
            "dxHtmlEditor-dialogLinkTextField": "Testo",
            "dxHtmlEditor-dialogLinkTargetField": "Apri link in una nuova finestra",
            "dxHtmlEditor-dialogImageCaption": "Agguingi Immagine",
            "dxHtmlEditor-dialogImageUrlField": "URL",
            "dxHtmlEditor-dialogImageAltField": "Testo alternativo",
            "dxHtmlEditor-dialogImageWidthField": "Larghezza (px)",
            "dxHtmlEditor-dialogImageHeightField": "Altezza (px)",
            "dxHtmlEditor-dialogInsertTableRowsField": "!TODO",
            "dxHtmlEditor-dialogInsertTableColumnsField": "!TODO",
            "dxHtmlEditor-dialogInsertTableCaption": "!TODO",
            "dxHtmlEditor-dialogUpdateImageCaption": "!TODO",
            "dxHtmlEditor-dialogImageUpdateButton": "!TODO",
            "dxHtmlEditor-dialogImageAddButton": "!TODO",
            "dxHtmlEditor-dialogImageSpecifyUrl": "!TODO",
            "dxHtmlEditor-dialogImageSelectFile": "!TODO",
            "dxHtmlEditor-dialogImageKeepAspectRatio": "!TODO",
            "dxHtmlEditor-dialogImageEncodeToBase64": "!TODO",
            "dxHtmlEditor-heading": "Intestazione",
            "dxHtmlEditor-normalText": "Testo Normale",
            "dxHtmlEditor-background": "TODO",
            "dxHtmlEditor-bold": "TODO",
            "dxHtmlEditor-color": "TODO",
            "dxHtmlEditor-font": "TODO",
            "dxHtmlEditor-italic": "TODO",
            "dxHtmlEditor-link": "TODO",
            "dxHtmlEditor-image": "TODO",
            "dxHtmlEditor-size": "TODO",
            "dxHtmlEditor-strike": "TODO",
            "dxHtmlEditor-subscript": "TODO",
            "dxHtmlEditor-superscript": "TODO",
            "dxHtmlEditor-underline": "TODO",
            "dxHtmlEditor-blockquote": "TODO",
            "dxHtmlEditor-header": "TODO",
            "dxHtmlEditor-increaseIndent": "TODO",
            "dxHtmlEditor-decreaseIndent": "TODO",
            "dxHtmlEditor-orderedList": "TODO",
            "dxHtmlEditor-bulletList": "TODO",
            "dxHtmlEditor-alignLeft": "TODO",
            "dxHtmlEditor-alignCenter": "TODO",
            "dxHtmlEditor-alignRight": "TODO",
            "dxHtmlEditor-alignJustify": "TODO",
            "dxHtmlEditor-codeBlock": "TODO",
            "dxHtmlEditor-variable": "TODO",
            "dxHtmlEditor-undo": "TODO",
            "dxHtmlEditor-redo": "TODO",
            "dxHtmlEditor-clear": "TODO",
            "dxHtmlEditor-insertTable": "TODO",
            "dxHtmlEditor-insertHeaderRow": "TODO",
            "dxHtmlEditor-insertRowAbove": "TODO",
            "dxHtmlEditor-insertRowBelow": "TODO",
            "dxHtmlEditor-insertColumnLeft": "TODO",
            "dxHtmlEditor-insertColumnRight": "TODO",
            "dxHtmlEditor-deleteColumn": "TODO",
            "dxHtmlEditor-deleteRow": "TODO",
            "dxHtmlEditor-deleteTable": "TODO",
            "dxHtmlEditor-cellProperties": "TODO",
            "dxHtmlEditor-tableProperties": "TODO",
            "dxHtmlEditor-insert": "TODO",
            "dxHtmlEditor-delete": "TODO",
            "dxHtmlEditor-border": "TODO",
            "dxHtmlEditor-style": "TODO",
            "dxHtmlEditor-width": "TODO",
            "dxHtmlEditor-height": "TODO",
            "dxHtmlEditor-borderColor": "TODO",
            "dxHtmlEditor-tableBackground": "TODO",
            "dxHtmlEditor-dimensions": "TODO",
            "dxHtmlEditor-alignment": "TODO",
            "dxHtmlEditor-horizontal": "TODO",
            "dxHtmlEditor-vertical": "TODO",
            "dxHtmlEditor-paddingVertical": "TODO",
            "dxHtmlEditor-paddingHorizontal": "TODO",
            "dxHtmlEditor-pixels": "TODO",
            "dxHtmlEditor-list": "TODO",
            "dxHtmlEditor-ordered": "TODO",
            "dxHtmlEditor-bullet": "TODO",
            "dxHtmlEditor-align": "TODO",
            "dxHtmlEditor-center": "TODO",
            "dxHtmlEditor-left": "TODO",
            "dxHtmlEditor-right": "TODO",
            "dxHtmlEditor-indent": "TODO",
            "dxHtmlEditor-justify": "TODO",
            "dxFileManager-newDirectoryName": "TODO",
            "dxFileManager-rootDirectoryName": "TODO",
            "dxFileManager-errorNoAccess": "TODO",
            "dxFileManager-errorDirectoryExistsFormat": "TODO",
            "dxFileManager-errorFileExistsFormat": "TODO",
            "dxFileManager-errorFileNotFoundFormat": "TODO",
            "dxFileManager-errorDirectoryNotFoundFormat": "TODO",
            "dxFileManager-errorWrongFileExtension": "TODO",
            "dxFileManager-errorMaxFileSizeExceeded": "TODO",
            "dxFileManager-errorInvalidSymbols": "TODO",
            "dxFileManager-errorDefault": "TODO",
            "dxFileManager-errorDirectoryOpenFailed": "TODO",
            "dxDiagram-categoryGeneral": "TODO",
            "dxDiagram-categoryFlowchart": "TODO",
            "dxDiagram-categoryOrgChart": "TODO",
            "dxDiagram-categoryContainers": "TODO",
            "dxDiagram-categoryCustom": "TODO",
            "dxDiagram-commandExportToSvg": "TODO",
            "dxDiagram-commandExportToPng": "TODO",
            "dxDiagram-commandExportToJpg": "TODO",
            "dxDiagram-commandUndo": "TODO",
            "dxDiagram-commandRedo": "TODO",
            "dxDiagram-commandFontName": "TODO",
            "dxDiagram-commandFontSize": "TODO",
            "dxDiagram-commandBold": "TODO",
            "dxDiagram-commandItalic": "TODO",
            "dxDiagram-commandUnderline": "TODO",
            "dxDiagram-commandTextColor": "TODO",
            "dxDiagram-commandLineColor": "TODO",
            "dxDiagram-commandLineWidth": "TODO",
            "dxDiagram-commandLineStyle": "TODO",
            "dxDiagram-commandLineStyleSolid": "TODO",
            "dxDiagram-commandLineStyleDotted": "TODO",
            "dxDiagram-commandLineStyleDashed": "TODO",
            "dxDiagram-commandFillColor": "TODO",
            "dxDiagram-commandAlignLeft": "TODO",
            "dxDiagram-commandAlignCenter": "TODO",
            "dxDiagram-commandAlignRight": "TODO",
            "dxDiagram-commandConnectorLineType": "TODO",
            "dxDiagram-commandConnectorLineStraight": "TODO",
            "dxDiagram-commandConnectorLineOrthogonal": "TODO",
            "dxDiagram-commandConnectorLineStart": "TODO",
            "dxDiagram-commandConnectorLineEnd": "TODO",
            "dxDiagram-commandConnectorLineNone": "TODO",
            "dxDiagram-commandConnectorLineArrow": "TODO",
            "dxDiagram-commandFullscreen": "TODO",
            "dxDiagram-commandUnits": "TODO",
            "dxDiagram-commandPageSize": "TODO",
            "dxDiagram-commandPageOrientation": "TODO",
            "dxDiagram-commandPageOrientationLandscape": "TODO",
            "dxDiagram-commandPageOrientationPortrait": "TODO",
            "dxDiagram-commandPageColor": "TODO",
            "dxDiagram-commandShowGrid": "TODO",
            "dxDiagram-commandSnapToGrid": "TODO",
            "dxDiagram-commandGridSize": "TODO",
            "dxDiagram-commandZoomLevel": "TODO",
            "dxDiagram-commandAutoZoom": "TODO",
            "dxDiagram-commandFitToContent": "TODO",
            "dxDiagram-commandFitToWidth": "TODO",
            "dxDiagram-commandAutoZoomByContent": "TODO",
            "dxDiagram-commandAutoZoomByWidth": "TODO",
            "dxDiagram-commandSimpleView": "TODO",
            "dxDiagram-commandCut": "TODO",
            "dxDiagram-commandCopy": "TODO",
            "dxDiagram-commandPaste": "TODO",
            "dxDiagram-commandSelectAll": "TODO",
            "dxDiagram-commandDelete": "TODO",
            "dxDiagram-commandBringToFront": "TODO",
            "dxDiagram-commandSendToBack": "TODO",
            "dxDiagram-commandLock": "TODO",
            "dxDiagram-commandUnlock": "TODO",
            "dxDiagram-commandInsertShapeImage": "TODO",
            "dxDiagram-commandEditShapeImage": "TODO",
            "dxDiagram-commandDeleteShapeImage": "TODO",
            "dxDiagram-commandLayoutLeftToRight": "TODO",
            "dxDiagram-commandLayoutRightToLeft": "TODO",
            "dxDiagram-commandLayoutTopToBottom": "TODO",
            "dxDiagram-commandLayoutBottomToTop": "TODO",
            "dxDiagram-unitIn": "TODO",
            "dxDiagram-unitCm": "TODO",
            "dxDiagram-unitPx": "TODO",
            "dxDiagram-dialogButtonOK": "TODO",
            "dxDiagram-dialogButtonCancel": "TODO",
            "dxDiagram-dialogInsertShapeImageTitle": "TODO",
            "dxDiagram-dialogEditShapeImageTitle": "TODO",
            "dxDiagram-dialogEditShapeImageSelectButton": "TODO",
            "dxDiagram-dialogEditShapeImageLabelText": "TODO",
            "dxDiagram-uiExport": "TODO",
            "dxDiagram-uiProperties": "TODO",
            "dxDiagram-uiSettings": "TODO",
            "dxDiagram-uiShowToolbox": "TODO",
            "dxDiagram-uiSearch": "TODO",
            "dxDiagram-uiStyle": "TODO",
            "dxDiagram-uiLayout": "TODO",
            "dxDiagram-uiLayoutTree": "TODO",
            "dxDiagram-uiLayoutLayered": "TODO",
            "dxDiagram-uiDiagram": "TODO",
            "dxDiagram-uiText": "TODO",
            "dxDiagram-uiObject": "TODO",
            "dxDiagram-uiConnector": "TODO",
            "dxDiagram-uiPage": "TODO",
            "dxDiagram-shapeText": "TODO",
            "dxDiagram-shapeRectangle": "TODO",
            "dxDiagram-shapeEllipse": "TODO",
            "dxDiagram-shapeCross": "TODO",
            "dxDiagram-shapeTriangle": "TODO",
            "dxDiagram-shapeDiamond": "TODO",
            "dxDiagram-shapeHeart": "TODO",
            "dxDiagram-shapePentagon": "TODO",
            "dxDiagram-shapeHexagon": "TODO",
            "dxDiagram-shapeOctagon": "TODO",
            "dxDiagram-shapeStar": "TODO",
            "dxDiagram-shapeArrowLeft": "TODO",
            "dxDiagram-shapeArrowUp": "TODO",
            "dxDiagram-shapeArrowRight": "TODO",
            "dxDiagram-shapeArrowDown": "TODO",
            "dxDiagram-shapeArrowUpDown": "TODO",
            "dxDiagram-shapeArrowLeftRight": "TODO",
            "dxDiagram-shapeProcess": "TODO",
            "dxDiagram-shapeDecision": "TODO",
            "dxDiagram-shapeTerminator": "TODO",
            "dxDiagram-shapePredefinedProcess": "TODO",
            "dxDiagram-shapeDocument": "TODO",
            "dxDiagram-shapeMultipleDocuments": "TODO",
            "dxDiagram-shapeManualInput": "TODO",
            "dxDiagram-shapePreparation": "TODO",
            "dxDiagram-shapeData": "TODO",
            "dxDiagram-shapeDatabase": "TODO",
            "dxDiagram-shapeHardDisk": "TODO",
            "dxDiagram-shapeInternalStorage": "TODO",
            "dxDiagram-shapePaperTape": "TODO",
            "dxDiagram-shapeManualOperation": "TODO",
            "dxDiagram-shapeDelay": "TODO",
            "dxDiagram-shapeStoredData": "TODO",
            "dxDiagram-shapeDisplay": "TODO",
            "dxDiagram-shapeMerge": "TODO",
            "dxDiagram-shapeConnector": "TODO",
            "dxDiagram-shapeOr": "TODO",
            "dxDiagram-shapeSummingJunction": "TODO",
            "dxDiagram-shapeContainerDefaultText": "TODO",
            "dxDiagram-shapeVerticalContainer": "TODO",
            "dxDiagram-shapeHorizontalContainer": "TODO",
            "dxDiagram-shapeCardDefaultText": "TODO",
            "dxDiagram-shapeCardWithImageOnLeft": "TODO",
            "dxDiagram-shapeCardWithImageOnTop": "TODO",
            "dxDiagram-shapeCardWithImageOnRight": "TODO",
            "dxGantt-dialogTitle": "TODO",
            "dxGantt-dialogStartTitle": "TODO",
            "dxGantt-dialogEndTitle": "TODO",
            "dxGantt-dialogProgressTitle": "TODO",
            "dxGantt-dialogResourcesTitle": "TODO",
            "dxGantt-dialogResourceManagerTitle": "TODO",
            "dxGantt-dialogTaskDetailsTitle": "TODO",
            "dxGantt-dialogEditResourceListHint": "TODO",
            "dxGantt-dialogEditNoResources": "TODO",
            "dxGantt-dialogButtonAdd": "TODO",
            "dxGantt-contextMenuNewTask": "TODO",
            "dxGantt-contextMenuNewSubtask": "TODO",
            "dxGantt-contextMenuDeleteTask": "TODO",
            "dxGantt-contextMenuDeleteDependency": "TODO",
            "dxGantt-dialogTaskDeleteConfirmation": "TODO",
            "dxGantt-dialogDependencyDeleteConfirmation": "TODO",
            "dxGantt-dialogResourcesDeleteConfirmation": "TODO",
            "dxGantt-dialogConstraintCriticalViolationMessage": "TODO",
            "dxGantt-dialogConstraintViolationMessage": "TODO",
            "dxGantt-dialogCancelOperationMessage": "TODO",
            "dxGantt-dialogDeleteDependencyMessage": "TODO",
            "dxGantt-dialogMoveTaskAndKeepDependencyMessage": "TODO",
            "dxGantt-dialogConstraintCriticalViolationSeveralTasksMessage": "TODO",
            "dxGantt-dialogConstraintViolationSeveralTasksMessage": "TODO",
            "dxGantt-dialogDeleteDependenciesMessage": "TODO",
            "dxGantt-dialogMoveTaskAndKeepDependenciesMessage": "TODO",
            "dxGantt-undo": "TODO",
            "dxGantt-redo": "TODO",
            "dxGantt-expandAll": "TODO",
            "dxGantt-collapseAll": "TODO",
            "dxGantt-addNewTask": "TODO",
            "dxGantt-deleteSelectedTask": "TODO",
            "dxGantt-zoomIn": "TODO",
            "dxGantt-zoomOut": "TODO",
            "dxGantt-fullScreen": "TODO",
            "dxGantt-quarter": "TODO",
            "dxGantt-sortingAscendingText": "Ordinamento ascendente",
            "dxGantt-sortingDescendingText": "Ordinamento discendente",
            "dxGantt-sortingClearText": "Annulla ordinamento",
            "dxGantt-showResources": "TODO",
            "dxGantt-showDependencies": "TODO",
            "dxGantt-dialogStartDateValidation": "TODO",
            "dxGantt-dialogEndDateValidation": "TODO"
        }
    })
}));
