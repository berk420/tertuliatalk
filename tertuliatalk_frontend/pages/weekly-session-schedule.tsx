import styled from 'styled-components';
import AutofitGrid from 'components/AutofitGrid';
import Page from 'components/Page';
import { media } from 'utils/media';
import * as React from 'react';
import Accordion from 'components/Accordion';
import Button from 'components/Button';
import RichText from 'components/RichText';


const communityPrograms = [
  {
    id: '1',
    title: 'Community Program1',
    description: 'First Comunity Program',
    date: '2024-07-12',
    time: '15:00',
    duration: '1 hour',
    location: 'Zoom',
    link: 'https://zoom.us/1234',
    isCommunity: true
  },
  {
    id: '2',
    title: 'Comunity Program2',
    description: 'Second Comunity Program',
    date: '2024-07-30',
    time: '16:00',
    duration: '1 hour',
    location: 'Zoom',
    link: 'https://zoom.us/1234',
    isCommunity: true
  },
  {
    id: '3',
    title: 'Comunity Program3',
    description: 'Third Comunity Program',
    date: '2024-07-27',
    time: '16:00',
    duration: '1 hour',
    location: 'Zoom',
    link: 'https://zoom.us/1234',
    isCommunity: true
  },

];

const nativePrograms = [
  {
    id: '3',
    title: 'Individual Program1',
    description: 'First Individual Program',
    date: '2024-08-22',
    time: '17:00',
    duration: '1 hour',
    location: 'Zoom',
    link: 'https://zoom.us/1234',
    isCommunity: false
  },
  {
    id: '4',
    title: 'Individual Program2',
    description: 'Second Individual Program',
    date: '2024-07-11',
    time: '18:00',
    duration: '1 hour',
    location: 'Zoom',
    link: 'https://zoom.us/1234',
    isCommunity: false
  },
];


export default function FeaturesPage() {
  const [expanded, setExpanded] = React.useState<string | false>(false);
  const [programs, setPrograms] = React.useState<any>(nativePrograms)

  const handleChange =
    (panel: string) => (event: React.SyntheticEvent, isExpanded: boolean) => {
      setExpanded(isExpanded ? panel : false);
    };

  return (
    <Page title="Haftalık oturum Programı">

      {/*<FormSection/>*/}

      <WholeFrame>


        <Wrapper>
          <Header>
            <Session>

              <Button onClick={() => setPrograms(nativePrograms)} >Bireysel</Button>
              <Button onClick={() => setPrograms(communityPrograms)}>Toplu</Button>

            </Session>
            <PassWeek>
              <Button>önceki hafta</Button>
              <RichText>Tarih</RichText>
              <Button>sonraki hafta</Button>


            </PassWeek>

          </Header>

          <Days>
            {
              programs &&
              communityPrograms.map((program, index) => (
                <Accordion title={`${program.date} / ${program.time}`} key={index}>
                  <Meetings>
                    <Container>
                      <FlexBetween>
                        <TitleDescription>
                          <h1>{program.title}</h1>
                          <p>{program.description}</p>
                        </TitleDescription>
                        <ColumnFlex>
                          <FlexAlignCenter>
                            <h2>{program.time} /&nbsp;</h2>
                            <strong>{program.duration}</strong>
                          </FlexAlignCenter>
                          <Location>{program.location}</Location>
                        </ColumnFlex>
                      </FlexBetween>
                      <Button href={program.link} target="_blank">Katıl</Button>
                    </Container>
                  </Meetings>
                </Accordion>
              ))
            }
          </Days>
        </Wrapper>
      </WholeFrame>
    </Page>
  );
}


const Days = styled.div`

    display: flex;
    background-color: #f5f5dc;
    width: 100%;
    height: 100%;
    display: flex;
    flex-direction: column;
      gap: 1rem;

`;

const Header = styled.div`

    display: flex;
    background-color: #f5f5dc;
    width: 100%;
    height: 15rem;
    display: flex;
    flex-direction: column;
`;


const Session = styled.div`
  background-color: #0FE728;
  width: 98%;
  height: 6rem;
  margin: 1rem;
  padding-left: 1rem;
  display: flex;
  gap: 1rem;
  align-items: center;  /* Butonları dikeyde ortalamak için */
`;

const PassWeek = styled.div`
  background-color: #0FE728;
  width: 98%;
  height: 6rem;
  padding-top: 0rem;
  margin: 1rem;
  display: flex;
  justify-content: space-between;
  align-items: center;
`;





const Meetings = styled.div`
    background-color: transparent;
    width:100%;
    height:15rem;
    margin-top: 1rem;

  
`;







const WholeFrame = styled.div`
    background-color: #f4a460;

    width:100%;
    height:100%;

  }
`;



const Wrapper = styled.div`
    background-color: #ff0;

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
  padding-inline: 3rem;
`;

const FlexBetween = styled.div`
  display: flex;
  align-items: center;
  justify-content: space-between;
`;

const TitleDescription = styled.div`
  h1 {
    margin: 0;
  }
  p {
    margin: 0;
  }
`;

const ColumnFlex = styled.div`
  display: flex;
  flex-direction: column;
`;

const FlexAlignCenter = styled.div`
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