import styled from 'styled-components';
import { Days as EnumDays } from 'types/enums';
import AutofitGrid from 'components/AutofitGrid';
import Page from 'components/Page';
import { media } from 'utils/media';
import Accordion from 'components/Accordion';
import Button from 'components/Button';
import RichText from 'components/RichText';
import { times } from 'lodash';
import Quote from 'components/Quote';
import SectionTitle from 'components/SectionTitle';
import { nextSevenDateFormatter } from 'utils/formatDate';
import React, { useEffect, useState } from 'react';



export default function FeaturesPage() {
  const [role, setRole] = useState<string | null>(null);

  useEffect(() => {
    const userRole = localStorage.getItem('userRole');
    console.log('userRole:', userRole);

    if (userRole) {
      setRole(userRole);
    }
  }, []);

  return (
    <Page title="Profil ekranı">
      <WholeFrame>
        {role === null ? (
          <RichText> Lütfen giriş yapınız </RichText>
        ) : (
          <>
            {role === "Teacher" && (
              <RichText>Teacher</RichText>
            )}
            {role === "Student" && (
              <RichText>Student</RichText>
            )}
            {role === "User" && (
              <RichText>Lütfen kayıt olunuz</RichText>
            )}
            {role === "SuperAdmin" && (
              <RichText>SuperAdmin</RichText>
            )}
          </>
        )}

      </WholeFrame>
    </Page>
  );
}


const WholeFrame = styled.div`
  border-radius: 1rem;
  background-color: #f4a460;
  width: 100%;
  height: 100%;
`;

const Wrapper = styled.div`
border-radius: 1rem;
  background-color: #f4a460;

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
gap: 1rem;
  display: flex;
  flex-direction: column;
`;

