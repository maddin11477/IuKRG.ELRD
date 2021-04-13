$(function () {
    var l = abp.localization.getResource('ELRD');
    var createModal = new abp.ModalManager(abp.appPath + 'Units/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Units/EditModal');

    var dataTable = $('#UnitsTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(iuKRG.eLRD.units.unit.getList),
            columnDefs: [
                {
                    title: l('BaseUnit:Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Edit'),
                                    visible: abp.auth.isGranted('ELRD.Units.Edit'),
                                    action: function (data) {
                                        editModal.open({ id: data.record.id });
                                    }
                                },
                                {
                                    text: l('Delete'),
                                    visible: abp.auth.isGranted('ELRD.Units.Delete'),
                                    confirmMessage: function (data) {
                                        return l('UnitDeletionConfirmationMessage', data.record.callsign);
                                    },
                                    action: function (data) {
                                        iuKRG.eLRD.units.unit
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
                    title: l('BaseUnit:Callsign'),
                    data: "callsign"
                },
                {
                    title: l('BaseUnit:Type'),
                    data: "type",
                    render: function (data) {
                        return l('Enum:UnitType:' + data);
                    }
                },
                {
                    title: l('BaseUnit:CrewCount'),
                    data: "crewCount"
                },
                {
                    title: l('BaseUnit:CreationTime'), data: "creationTime",
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

    $('#NewUnitButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});