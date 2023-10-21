export type QFormatFunction = (val: string) => string;
export type QSortFunction = (a: string, b: string) => number;

/** Alignment options for a column in a table. */
export enum QColumnAlign {
  /** Left, the default alignment. */
  Left = 'left',
  /** Centered, usually for booleans. */
  Center = 'center',
  /** Right aligned, default for numeric values. */
  Right = 'right',
}

/** The data types which help in determining characteritics for a control. */
export enum QDataType {
  /** A true or false or bit value. */
  boolean,
  /** A date construct. */
  date,
  /** A numeric value. */
  number,
  /** A text value. */
  string,
}

/** The various default toast types, you can add others if you wish. */
export enum ToastType {
  /** A positive green themed toast. */
  Positive = 'positive',
  /** A negative red themed toast. */
  Negative = 'negative',
  /** A warning orange themed toast. */
  Warning = 'warning',
  /** A informative neutral themed toast. */
  Information = 'info',
  /** A ongoing themed toast. */
  Ongoing = 'ongoing',
}

/** The various quasar supported transiation types. */
export enum QTransitionType {
  /** A fade effect. */
  Fade = 'fade',
  /** Flip in from the top. */
  FlipDown = 'flip-down',
  /** Flip in from the left. */
  FlipLeft = 'flip-left',
  /** Flip in from the right. */
  FlipRight = 'flip-right',
  /** Flip in from the bottom. */
  FlipUp = 'flip-up',
  /** Jump in from the top. */
  JumpDown = 'jump-down',
  /** Jump in from the left. */
  JumpLeft = 'jump-left',
  /** Jump in from the right. */
  JumpRight = 'jump-right',
  /** Jump in from the bottom. */
  JumpUp = 'jump-up',
  /** No effect. */
  None = 'none',
  /** A scaling effect. */
  Scale = 'scale',
  /** A rtating effect. */
  Rotate = 'rotate',
  /** Slide in from the top. */
  SlideDown = 'slide-down',
  /** Slide in from the left. */
  SlideLeft = 'slide-left',
  /** Slide in from the right. */
  SlideRight = 'slide-right',
  /** Slide in from the bottom. */
  SlideUp = 'slide-up',
}

/**
 * Class: QSelectOption
 *
 * - A select option that is bound to a quasar select control.
 *
 */
export class QSelectOption {
  label: string;
  value: string;

  constructor(label: string, value?: string) {
    this.label = label;
    this.value = label;
    if (value != null) {
      this.value = value;
    }
  }
}

/**
 * Class: DBColumn
 *
 * - A meta data class representing a database column.
 *
 */
export class DBColumn {
  name: string;
  originalName: string;
  label: string;
  required: boolean;
  field: string;
  type: string;
  dataType: QDataType;

  constructor(
    name: string,
    originalName: string,
    label: string,
    dataType: QDataType
  ) {
    this.name = name;
    this.originalName = originalName;
    this.label = label;
    this.required = true;
    this.field = this.name;
    this.type = 'string';
    this.dataType = dataType;
    if (dataType == QDataType.date) {
      this.type = 'Date';
    } else if (dataType == QDataType.number) {
      this.type = 'number';
    } else if (dataType == QDataType.boolean) {
      this.type = 'boolean';
    }
  }
}

export class QPagination {
  sortBy?: string | undefined;
  decsending?: boolean | undefined;
  page?: number | undefined;
  rowsPerPage?: number | undefined;
  rowsNumber?: number | undefined;

  constructor() {
    this.sortBy = undefined;
    this.decsending = undefined;
    this.page = undefined;
    this.rowsPerPage = undefined;
    this.rowsNumber = undefined;
  }
}
/**
 * Class: QTableColumnHeader
 *
 * - A special class which creates a table column header from a database column.
 *
 */
export class QTableColumnHeader extends DBColumn {
  format?: QFormatFunction;
  sort?: QSortFunction;
  sortable: boolean;
  align: QColumnAlign;
  dataType: QDataType;

  constructor(
    name: string,
    originalName: string,
    label: string,
    dataType: QDataType
  ) {
    super(name, originalName, label, dataType);
    this.dataType = dataType;
    if (dataType == QDataType.date) {
      this.field = this.name + 'Formatted';
    }
    this.format = undefined;
    if (dataType == QDataType.string) {
      this.sort = (a, b) => a.localeCompare(b);
    } else if (dataType == QDataType.number) {
      this.sort = (a, b) => {
        if (isNaN(parseInt(a)) && isNaN(parseInt(b))) return 0;
        else if (!isNaN(parseInt(a)) && isNaN(parseInt(b))) return 1;
        else if (isNaN(parseInt(a)) && !isNaN(parseInt(b))) return -1;
        else return parseInt(a) - parseInt(b);
      };
    } else if (dataType == QDataType.date) {
      this.sort = (a, b) => {
        const aIsDate = Object.prototype.toString.call(a) === '[object Date]';
        const bIsDate = Object.prototype.toString.call(a) === '[object Date]';
        if (!aIsDate && !bIsDate) return 0;
        else if (aIsDate && !bIsDate) return 1;
        else if (!aIsDate && bIsDate) return -1;
        else {
          if (Date.parse(a) > Date.parse(b)) return 1;
          else if (Date.parse(a) < Date.parse(b)) return -1;
          else return 0;
        }
      };
    } else if (dataType == QDataType.boolean) {
      this.sort = (a, b) => {
        return (
          Number(this.convertToBoolean(a)) - Number(this.convertToBoolean(b))
        );
      };
    }
    this.sortable = true;

    this.align = QColumnAlign.Left;
    if (dataType == QDataType.number) {
      this.align = QColumnAlign.Right;
    } else if (dataType == QDataType.boolean) {
      this.align = QColumnAlign.Center;
    }
  }

  convertToBoolean(val: string): boolean {
    const trueValues = [
      'true',
      'True',
      'TRUE',
      '1',
      'on',
      'On',
      'ON',
      'yes',
      'Yes',
      'YES',
    ];

    return trueValues.indexOf(String(val)) >= 0;
  }
}

/**
 * Class: QTableColumnHeaderFromDBColumn
 *
 * - A special class which creates a table column header from a database column.
 *
 */
export class QTableColumnHeaderFromDBColumn extends QTableColumnHeader {
  dbColumn: DBColumn | undefined;
  constructor(dbColumn: DBColumn | undefined) {
    if (dbColumn != null) {
      super(
        dbColumn.name,
        dbColumn.originalName,
        dbColumn.label,
        dbColumn.dataType
      );
      this.dbColumn = dbColumn;
    } else {
      throw 'QTableColumnHeaderFromDBColumn cannot be initialized with an undefined dbColumn.';
    }
  }
}
