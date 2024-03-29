﻿$(function () {
    var l = abp.localization.getResource('ELRD');
    var createModal = new abp.ModalManager(abp.appPath + 'Hospitals/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Hospitals/EditModal');

    var dataTable = $('#HospitalsTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(iuKRG.eLRD.hospitals.hospital.getList),
            columnDefs: [
                {
                    title: l('BaseHospitals:Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Edit'),
                                    visible: abp.auth.isGranted('ELRD.Basedata.HospitalCU'),
                                    action: function (data) {
                                        editModal.open({ id: data.record.id });
                                    }
                                },
                                {
                                    text: l('Delete'),
                                    visible: abp.auth.isGranted('ELRD.Basedata.HospitalD'),
                                    confirmMessage: function (data) {
                                        return l('HospitalDeletionConfirmationMessage', data.record.name);
                                    },
                                    action: function (data) {
                                        iuKRG.eLRD.hospitals.hospital
                                            .delete(data.record.id)
                                            .then(function () {
                                                abp.notify.success(l('SuccessfullyDeleted', data.record.name));
                                                dataTable.ajax.reload();
                                            });
                                    }
                                }
                            ]
                    }
                },
                {
                    title: l('BaseHospitals:Name'),
                    data: "name"
                },
                {
                    title: l('BaseHospitals:City'),
                    data: "city"
                },
                {
                    title: l('BaseHospitals:Long'),
                    data: "long"
                },
                {
                    title: l('BaseHospitals:Lat'),
                    data: "lat"
                },
                {
                    title: l('BaseHospitals:CreationTime'), data: "creationTime",
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
        abp.notify.success(l('SuccessfullyCreated'));
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
        abp.notify.success(l('SuccessfullyEdited'));
    });

    $('#NewHospitalButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});