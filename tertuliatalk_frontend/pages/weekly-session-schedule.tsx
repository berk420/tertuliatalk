"use client"
import styled from 'styled-components';
import React, { useEffect, useState } from 'react';
import Page from 'components/Page';
import Accordion from 'components/Accordion';
import Button from 'components/Button';
import { nextSevenDateFormatter } from 'utils/formatDate';
import StudentMeeting from 'views/SessionSchedule/StudentMeeting';
import { weeksArray } from 'mocks/weeks';
import { communityPrograms, nativePrograms, Program } from 'mocks/programs';


export default function FeaturesPage() {
  const [programs, setPrograms] = React.useState<Program[]>([]);
  const [weekIndex, setWeekIndex] = React.useState<number>(0);



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

  const [role, setRole] = useState<string | null>(null);

  useEffect(() => {
    const role = localStorage.getItem("userRole");
    if (role) {
      setRole(role);
    }
  }, []);


  return (
    <Page title="Haftalık oturum Programı">
      <WholeFrame>
        {role === null ? (
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
                  <Accordion title={weeks.day} subTitle={`Oturum Sayısı: ${programs
                    .filter((program) => program.id === weeks.id).length}`} key={index}>
                    {programs &&
                      programs
                        .filter((program) => program.id === weeks.id)
                        .map((program, index) => (
                          <StudentMeeting key={index} index={index} program={program} />
                        ))
                    }
                  </Accordion>)

                )}
            </Days>
          </Wrapper>
        ) : (
          <>
            {role === "Instructor" && (
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
                      <Accordion title={weeks.day} subTitle={`Oturum Sayısı: ${programs.length}`} key={index} setPrograms={setPrograms}>
                        {
                        }
                      </Accordion>
                    ))}
                </Days>
              </Wrapper>
            )}
            {role === "Student" && (
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
                      <Accordion title={weeks.day} subTitle={`Oturum Sayısı: ${programs.length}`} key={index}>
                        {
                        }
                      </Accordion>)

                    )}
                </Days>
              </Wrapper>
            )}
            {role === "User" && (
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
                      <Accordion title={weeks.day} subTitle={`Oturum Sayısı: ${programs.length}`} key={index}>
                        {
                        }
                      </Accordion>)

                    )}
                </Days>
              </Wrapper>)}
            {role === "SuperAdmin" && (
              <p>SuperAdmin</p>
            )}
            {/* Uncomment below if needed
              <CustomButtonGroup>
                <Button onClick={() => setIsModalOpened(true)}>
                  Formu doldur<span>&rarr;</span>
                </Button>
              </CustomButtonGroup>
              */}
          </>
        )}
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
  background-color: rgb(var(--navbarBackground));
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
  background-color: rgb(var(--navbarBackground));
  border-radius: 1rem;
  padding: 2rem;
   width: 100%;
  height: 100%;
  display: flex;
  justify-content: space-between;
  align-items: center;
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


export const ColumnFlex = styled.div`
user-select: none;
gap: 1rem;
  display: flex;
  flex-direction: column;
`;

export const RowFlex = styled.div`
  gap: 1rem;
  display: flex;
  flex-direction: row;
  justify-content: center
`;
