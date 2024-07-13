import styled from 'styled-components';
import { Days as EnumDays } from 'types/enums';
import AutofitGrid from 'components/AutofitGrid';
import Page from 'components/Page';
import { media } from 'utils/media';
import * as React from 'react';
import Accordion from 'components/Accordion';
import Button from 'components/Button';
import RichText from 'components/RichText';
import { times } from 'lodash';
import Quote from 'components/Quote';
import SectionTitle from 'components/SectionTitle';
import { nextSevenDateFormatter } from 'utils/formatDate';


type Times = {
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

const weeksArray = [week28, week29];

type Program = {
  id: string;
  title: string;
  description: string;
  date: string;
  time: string;
  duration: string;
  location: string;
  link: string;
  isCommunity: boolean;
  isActive: boolean;  /* -> this prop is used to show the active programs 
                            if we create cron jobs that run every hour in the backend, we can handle this.
                        */
};

const communityPrograms: Program[] = [
  {
    id: '28.1',
    title: 'Community Program1',
    description: 'First Community Program',
    date: '2024-07-12',
    time: '15:00',
    duration: '1 hour',
    location: 'Zoom',
    link: 'https://zoom.us/1234',
    isCommunity: true,
    isActive: false,
  },
  {
    id: '28.2',
    title: 'Community Program2',
    description: 'Second Community Program',
    date: '2024-07-30',
    time: '16:00',
    duration: '1 hour',
    location: 'Zoom',
    link: 'https://zoom.us/1234',
    isCommunity: true,
    isActive: true,
  },
  {
    id: '28.3',
    title: 'Community Program3',
    description: 'Third Community Program',
    date: '2024-07-27',
    time: '16:00',
    duration: '1 hour',
    location: 'Zoom',
    link: 'https://zoom.us/1234',
    isCommunity: true,
    isActive: true,
  },
];

const nativePrograms: Program[] = [
  {
    id: '28.2',
    title: 'Individual Program1',
    description: 'First Individual Program',
    date: '2024-08-22',
    time: '17:00',
    duration: '1 hour',
    location: 'Zoom',
    link: 'https://zoom.us/1234',
    isCommunity: false,
    isActive: false,

  },
  {
    id: '28.2',
    title: 'Individual Program2',
    description: 'Second Individual Program',
    date: '2024-07-11',
    time: '18:00',
    duration: '1 hour',
    location: 'Zoom',
    link: 'https://zoom.us/1234',
    isCommunity: false,
    isActive: true,
  },
];

export default function FeaturesPage() {
  //const [expanded, setExpanded] = React.useState<string | false>(false);
  const [programs, setPrograms] = React.useState<Program[]>(nativePrograms);
  const [weekIndex, setWeekIndex] = React.useState<number>(0);

  //const handleChange =
  //  (panel: string) => (event: React.SyntheticEvent, isExpanded: boolean) => {
  //    setExpanded(isExpanded ? panel : false);
  //  };

  const downloadPdf = () => {
    const link = document.createElement('a');
    link.href = 'http://localhost:3000/example.pdf';
    link.download = 'example';
    link.click();
  }

  const handleNextWeek = () => {
    if (weekIndex === weeksArray.length - 1) {
      return;
    }
    setWeekIndex((prevIndex) => (prevIndex + 1) % weeksArray.length);
  };

  const handlePrevWeek = () => {
    if (weekIndex === 0) {
      return;
    }
    setWeekIndex((prevIndex) => {
      if (prevIndex === 0) {
        return weeksArray.length - 1; // Son haftaya dönmek için
      } else {
        return prevIndex - 1;
      }
    });
  };


  return (
    <Page title="Haftalık oturum Programı">
      <WholeFrame>
        <Wrapper>
          <Header>
            <Session>
              <Button onClick={() => setPrograms(nativePrograms)}>Bireysel</Button>
              <Button onClick={() => setPrograms(communityPrograms)}>Toplu</Button>
            </Session>
            <PassWeek>
              <Button onClick={handlePrevWeek}>önceki hafta</Button>
              <h1>{`Tarih: ${weeksArray[weekIndex][0].date} - ${nextSevenDateFormatter(weeksArray[weekIndex][0].date)}`}</h1>
              <Button onClick={handleNextWeek}>sonraki hafta</Button>
            </PassWeek>
          </Header>
          <Days>
            {weeksArray[weekIndex] &&
              weeksArray[weekIndex].map((weeks, index) => (
                <Accordion title={`${weeks.date} / ${weeks.day}`} subTitle={`Oturum Sayısı: ${programs
                  .filter((program) => program.id === weeks.id).length}`} key={index}>
                  {programs &&
                    programs
                      .filter((program) => program.id === weeks.id)
                      .map((program, index) => (
                        <Meetings key={index}>
                          <Container>
                            <FlexBetween>
                              <TitleDescription>
                                <h2>{program.title}</h2>
                                <p>{program.description}</p>
                              </TitleDescription>
                              <ColumnFlex>
                                <FlexAlignCenter>
                                  <RichText>{program.time} /&nbsp;</RichText>
                                  <RichText>{program.duration}</RichText>
                                </FlexAlignCenter>
                                <FlexAlignCenter>
                                  <Location>{program.location}</Location>
                                  <CustomCircle>2/4</CustomCircle>
                                </FlexAlignCenter>
                              </ColumnFlex>
                            </FlexBetween>
                            <FlexCenterBetween>
                              <Button onClick={downloadPdf} disabled={!program.isActive}>
                                Metaryali indir
                              </Button>
                              <Button href={program.link} target="_blank" disabled={!program.isActive}>
                                Randevu Oluştur
                              </Button>
                            </FlexCenterBetween>
                          </Container>
                        </Meetings>
                      ))
                  }
                </Accordion>
              ))}
          </Days>
        </Wrapper>
      </WholeFrame>
    </Page>
  );
}

const Days = styled.div`
border-radius: 1rem;
  display: flex;
  padding: 1rem;
  background-color: #f5f5dc;
  width: 100%;
  height: 100%;
  display: flex;
  flex-direction: column;
  gap: 1rem;
`;

const Header = styled.div`
border-radius: 1rem;
  display: flex;
  background-color: #f5f5dc;
  padding: 1rem;
  gap: 1rem;
  width: 100%;
  height: 100%;
  display: flex;
  flex-direction: column;
`;


const Session = styled.div`
  background-color: #06142a;
  border-radius: 1rem;
  padding: 2rem;
  width: 100%;
  height: 100%;
  display: flex;
  justidy-content: center;
  gap: 1rem;
  align-items: center; /* Butonları dikeyde ortalamak için */
`;

const PassWeek = styled.div`
  background-color: #06142a;
  border-radius: 1rem;
  padding: 2rem;
   width: 100%;
  height: 100%;
  display: flex;
  justify-content: space-between;
  align-items: center;
`;

const Meetings = styled.div`
  background-color: #f5f5dc;
  border-radius: 1rem;
  border-bottom: 1px solid #2c3540;
  padding: 1rem;
  width: 100%;
  margin-top: 1rem;
`;

const WholeFrame = styled.div`
border-radius: 1rem;
  background-color: #f4a460;
  width: 100%;
  height: 100%;
`;

const Wrapper = styled.div`
border-radius: 1rem;

  display: flex;
  flex-direction: column;
  background-color: #f5f5dc;
  width: 100%;
  height: 100%;
  & > *:not(:first-child) {
    margin-top: 1rem;
  }
`;

const CustomAutofitGrid = styled(AutofitGrid)`
  --autofit-grid-item-size: 40rem;

  ${media('<=tablet')} {
    --autofit-grid-item-size: 30rem;
  }

  ${media('<=phone')} {
    --autofit-grid-item-size: 100%;
  }
`;

const Container = styled.div`
`;

const FlexBetween = styled.div`
padding: 1rem;
  display: flex;
  align-items: center;
  justify-content: space-between;
`;

const TitleDescription = styled.div`
font-weight: bold;
color: black;  
  h1 {
    margin: 0;
  }
  p {
    margin: 0;
  }
`;

export const ColumnFlex = styled.div`
gap: 1rem;
  display: flex;
  flex-direction: column;
`;

const FlexAlignCenter = styled.div`
gap: 1rem;
  color: black;
  display: flex;
  align-items: center;

  h2 {
    margin: 0;
  }
  strong {
    margin-left: 0.5rem;
  }
`;

const Location = styled.strong`
color: black;
  margin-top: 0.5rem;
`;

const StyledButton = styled.a`
  display: inline-block;
  padding: 10px 20px;
  margin-top: 10px;
  font-size: 16px;
  text-align: center;
  text-decoration: none;
  color: #fff;
  background-color: #007bff;
  border-radius: 5px;
  cursor: pointer;
  &:hover {
    background-color: #0056b3;
  }
`;

const FlexCenterBetween = styled.div`
  display: flex;
  align-items: center;
  justify-content: center;
  gap: 2rem;
  height: 45px;
  overflow: hidden;
`;

const CustomCircle = styled.div`
color: white;
font-weight: bold;
display: flex;
justify-content: center;
  align-items: center;
  width: 5rem;
  height: 5rem;
  border-radius: 50%;
  background-color: #fd5221;
`;
