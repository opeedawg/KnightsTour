export const ChartOptions = {
  chart: {
    type: 'polarArea',
  },
  title: {
    text: 'Parental Guide',
    align: 'center',
    margin: 10,
    offsetX: 0,
    offsetY: 0,
    floating: false,
    style: {
      fontSize: '14px',
      fontWeight: 'bold',
      fontFamily: undefined,
      color: '#263238',
    },
  },
  stroke: {
    colors: ['#fff'],
  },
  fill: {
    opacity: 0.8,
  },
  labels: ['Nudity', 'Violence', 'Profanity', 'Alcohol/Drugs', 'Intensity'],
  colors: ['#f15bb5', '#0b090a', '#9b5de5', '#00f5d4', '#fee440'],
  xaxis: {
    show: false,
    axisBorder: {
      show: false,
    },
    axisTicks: {
      show: false,
    },
    maximum: 4,
  },
  yaxis: {
    show: false,
    axisBorder: {
      show: false,
    },
    axisTicks: {
      show: false,
    },
    crosshairs: {
      show: false,
    },
    labels: {
      formatter: function (value: number) {
        if (value == 1) return 'None';
        else if (value == 2) return 'Mild';
        else if (value == 3) return 'Moderate';
        else if (value == 4) return 'Severe';
        else return value;
      },
    },
  },
  legend: {
    show: false,
  },
};
