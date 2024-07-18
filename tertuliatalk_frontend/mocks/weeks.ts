import { Days as EnumDays } from 'types/enums';

export type Times = {
  id: string;
  date: string;
  day: EnumDays;
};

const week28: Times[] = [
  {
    id: '28.1',
    date: '08.11',
    day: EnumDays.Monday,
  },
  {
    id: '28.2',
    date: '09.11',
    day: EnumDays.Tuesday,
  },
  {
    id: '28.3',
    date: '10.11',
    day: EnumDays.Wednesday,
  },
  {
    id: '28.4',
    date: '11.11',
    day: EnumDays.Thursday,
  },
  {
    id: '28.5',
    date: '12.11',
    day: EnumDays.Friday,
  },
  {
    id: '28.6',
    date: '13.11',
    day: EnumDays.Saturday,
  },
  {
    id: '28.7',
    date: '14.11',
    day: EnumDays.Sunday,
  },
];

const week29: Times[] = [
  {
    id: '29.1',
    date: '15.11',
    day: EnumDays.Monday,
  },
  {
    id: '29.2',
    date: '16.11',
    day: EnumDays.Tuesday,
  },
  {
    id: '29.3',
    date: '17.11',
    day: EnumDays.Wednesday,
  },
  {
    id: '29.4',
    date: '18.11',
    day: EnumDays.Thursday,
  },
  {
    id: '29.5',
    date: '19.11',
    day: EnumDays.Friday,
  },
  {
    id: '29.6',
    date: '20.11',
    day: EnumDays.Saturday,
  },
  {
    id: '29.7',
    date: '21.11',
    day: EnumDays.Sunday,
  },
];

export const weeksArray = [week28, week29];
