export enum SortType {
  Name = 'name',
  Rating = 'rating',
  UserRating = 'userRating',
  Duration = 'duration',
  Quality = 'quality',
  Year = 'year',
  Adult = 'adult',
  CreatedDate = 'createdDate',
}

export class SortBins {
  sortType: SortType;
  bins: SortBin[];

  constructor(sortType: SortType) {
    this.sortType = sortType;
    this.bins = [];
    const minLimit = -1;
    const maxLimit = 1000 * 1000 * 1000;
    this.bins.push(new SortBin(sortType, null, null, minLimit, maxLimit)); // An empty all group.
    switch (this.sortType) {
      case SortType.CreatedDate: {
        this.bins.push(new SortBin(sortType, 'Today', '1 week ago', -1, 7));
        this.bins.push(
          new SortBin(sortType, '8 days ago', 'a month ago', 8, 30)
        );
        this.bins.push(
          new SortBin(sortType, 'A month ago', '3 months ago', 31, 90)
        );
        this.bins.push(
          new SortBin(sortType, '3 months ago', 'a year ago', 91, 365)
        );
        this.bins.push(
          new SortBin(sortType, 'More than a year', '', 365, 10000)
        );
        break;
      }
      case SortType.Adult: {
        for (let i = 0; i < 100; i = i + 10) {
          if (i < 90) {
            this.bins.push(
              new SortBin(sortType, i.toString(), (i + 9).toString(), i, i + 9)
            );
          } else {
            this.bins.push(
              new SortBin(
                sortType,
                i.toString(),
                (i + 10).toString(),
                i,
                i + 10
              )
            );
          }
        }
        break;
      }
      case SortType.Duration: {
        this.bins.push(new SortBin(sortType, null, '29 min', minLimit, 30 - 1));
        this.bins.push(new SortBin(sortType, '30 min', '59 min', 30, 60 - 1));
        this.bins.push(new SortBin(sortType, '60 min', '89 min', 60, 90 - 1));
        this.bins.push(new SortBin(sortType, '90 min', '119 min', 90, 120 - 1));
        this.bins.push(
          new SortBin(sortType, '120 min', '149 min', 120, 150 - 1)
        );
        this.bins.push(new SortBin(sortType, '150 min', null, 150, maxLimit));
        break;
      }
      case SortType.Name: {
        this.bins.push(new SortBin(sortType, null, '#', minLimit, 64));
        for (let i = 0; i < 26; i++) {
          this.bins.push(
            new SortBin(
              sortType,
              String.fromCharCode(i + 65),
              String.fromCharCode(i + 65),
              i + 65,
              i + 65
            )
          );
        }

        break;
      }
      case SortType.Quality: {
        this.bins.push(
          new SortBin(sortType, null, '249k', minLimit, 250 * 1000 - 1)
        );
        this.bins.push(
          new SortBin(sortType, '250k', '499k', 250 * 1000, 500 * 1000 - 1)
        );
        this.bins.push(
          new SortBin(sortType, '500k', '999k', 500 * 1000, 1000 * 1000 - 1)
        );
        this.bins.push(
          new SortBin(sortType, '1M', '1.54M', 1000 * 1000, 1540 * 1000 - 1)
        );
        this.bins.push(
          new SortBin(sortType, '1.55M', '4.9M', 1540 * 1000, 5000 * 1000 - 1)
        );
        this.bins.push(
          new SortBin(sortType, '5M', null, 5000 * 1000, maxLimit)
        );
        break;
      }
      case SortType.Rating: {
        for (let i = 0; i < 10; i++) {
          this.bins.push(
            new SortBin(sortType, i.toString(), (i + 1).toString(), i, i + 1)
          );
        }
        break;
      }
      case SortType.UserRating: {
        for (let i = 0; i < 10; i++) {
          this.bins.push(
            new SortBin(sortType, i.toString(), (i + 1).toString(), i, i + 1)
          );
        }
        break;
      }
      case SortType.Year: {
        this.bins.push(new SortBin(sortType, null, '1949', minLimit, 1949));
        for (let i = 1950; i < 2030; i = i + 10) {
          this.bins.push(
            new SortBin(sortType, i.toString(), (i + 9).toString(), i, i + 10)
          );
        }
        break;
      }
    }
  }
}

export class SortBin {
  sortType: SortType;
  minValueText: string | null;
  maxValueText: string | null;
  minValue: number;
  maxValue: number;
  count: number;
  name: string;

  constructor(
    sortType: SortType,
    minText: string | null,
    maxText: string | null,
    minValue: number,
    maxValue: number
  ) {
    this.sortType = sortType;
    this.minValueText = minText;
    this.maxValueText = maxText;
    this.minValue = minValue;
    this.maxValue = maxValue;
    this.count = 0;
    this.name = '*';

    if (this.minValueText && this.minValueText == this.maxValueText) {
      this.name = this.minValueText;
    } else {
      if (this.minValueText && this.maxValueText) {
        this.name = this.minValueText + ' to ' + this.maxValueText;
      } else if (this.minValueText && !this.maxValueText) {
        this.name = this.minValueText + ' and greater';
      } else if (!this.minValueText && this.maxValueText) {
        this.name = 'less than ' + this.maxValueText;
      } else if (!this.minValueText && !this.maxValueText) {
        this.name = 'ALL';
      }
    }
  }
}
