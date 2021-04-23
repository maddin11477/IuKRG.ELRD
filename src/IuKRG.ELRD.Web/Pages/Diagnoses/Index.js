$(function () {
    var l = abp.localization.getResource('ELRD');
    var createModal = new abp.ModalManager(abp.appPath + 'Diagnoses/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Diagnoses/EditModal');

    var dataTable = $('#DiagnosesTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(iuKRG.eLRD.diagnoses.diagnosis.getList),
            columnDefs: [
                {
                    title: l('BaseDiagnoses:Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Edit'),
                                    visible: abp.auth.isGranted('ELRD.Basedata.DiagnosisCU'),
                                    action: function (data) {
                                        editModal.open({ id: data.record.id });
                                    }
                                },
                                {
                                    text: l('Delete'),
                                    visible: abp.auth.isGranted('ELRD.Basedata.DiagnosisD'),
                                    confirmMessage: function (data) {
                                        return l('DiagnosisDeletionConfirmationMessage', data.record.callsign);
                                    },
                                    action: function (data) {
                                        iuKRG.eLRD.diagnoses.diagnosis
                                            .delete(data.record.id)
                                            .then(function () {
                                                abp.notify.info(l('SuccessfullyDeleted'));
                                                dataTable.ajax.reload();
                                            });
                                    }
                                }
                            ]
                    }
                },
                {
                    title: l('BaseDiagnoses:Category'),
                    data: "category"
                },
                {
                    title: l('BaseDiagnoses:Injury'),
                    data: "injury"
                },
                {
                    title: l('BaseDiagnoses:Location'),
                    data: "location"
                },
                {
                    title: l('BaseDiagnoses:CreationTime'), data: "creationTime",
                    render: function (data) {
                        return luxon
                            .DateTime
                            .fromISO(data, {
                                locale: abp.localization.currentCulture.name
                            }).toLocaleString(luxon.DateTime.DATETIME_SHORT);
                    }
                }
            ]
        })
    );

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewDiagnosisButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});