import { QColumnAlign, QDataType, QTableColumnHeader } from './quasar';

export const colRowAction: QTableColumnHeader = new QTableColumnHeader(
  'rowAction',
  'rowAction',
  'ACTIONS',
  QDataType.string
);

colRowAction.align = QColumnAlign.Center;
colRowAction.sortable = false;
