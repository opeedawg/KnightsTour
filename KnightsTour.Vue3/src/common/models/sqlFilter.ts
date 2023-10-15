import { FilterComparer, FilterDataType } from './enumerations';

export class SqlFilter {
  column: string;
  value: string;
  dataType: FilterDataType;
  comparer: FilterComparer;

  constructor(
    column: string,
    value: string,
    dataType?: FilterDataType,
    comparer?: FilterComparer
  ) {
    this.column = column;
    this.value = value;
    this.dataType = FilterDataType.String;
    if (dataType != null) {
      this.dataType = dataType;
    }
    this.comparer = FilterComparer.Equals;
    if (comparer != null) {
      this.comparer = comparer;
    }
  }
}
