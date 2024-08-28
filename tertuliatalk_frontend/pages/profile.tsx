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
//burada kullanıcıdan data gelecek
const sessionData = [
  { session: 'Oturum 1', date: '2024-08-25', description: 'Açıklama 1' },
  { session: 'Oturum 2', date: '2024-08-26', description: 'Açıklama 2' },
  { session: 'Oturum 3', date: '2024-08-27', description: 'Açıklama 3' },
];

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
          <RichText>Lütfen giriş yapınız</RichText>
        ) : (
          <>
            {role === "Teacher" && (
              <RichText>Teacher</RichText>
            )}
            {role === "Student" && (
              <>
                <ProfileWrapper>
                  <LeftColumn>
                    <ProfilePicture
                      src="https://cdn.pixabay.com/photo/2021/06/04/10/29/guy-6309458_960_720.jpg"
                      alt="Profil Fotoğrafı"
                    />
                    <Button>Düzenle</Button>
                    <Name>Adınız Soyadınız</Name>
                    <Description>Buraya sstring bir ifade gelecek.</Description>
                  </LeftColumn>
                  <RightColumn>
                    <InfoBox>
                      <h2>Kişisel Bilgiler</h2>
                      <ul>
                        <li>Yaş:</li>
                        <li>Hobiler:</li>
                        <li>Dil yeterlilik seviyesi:</li>
                        <li>Telefon: +90 123 456 78 90</li>
                      </ul>
                      <ButtonInfo>4 hakkınız kaldı</ButtonInfo>
                      <ButtonInfo>Aboneliğimi Duraklat</ButtonInfo>
                    </InfoBox>
                  </RightColumn>
                </ProfileWrapper>
                <BottomSection>
                    <Table>
                      <thead>
                        <tr>
                          <th>Katıldığım Oturumlar</th>
                          <th>Tarih</th>
                          <th>Açıklama</th>
                        </tr>
                      </thead>
                      <tbody>
                        {sessionData.map((item, index) => (
                          <tr key={index}>
                            <td>{item.session}</td>
                            <td>{item.date}</td>
                            <td>{item.description}</td>
                          </tr>
                        ))}
                      </tbody>
                    </Table>
                    
                    <ButtonWrapper><ButtonBottom>Tümünü Göster</ButtonBottom></ButtonWrapper>
                
                    
                </BottomSection>
              </>
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
  width: 100%;
  height: 100%;
`;

//**top profile
const ProfileWrapper = styled.div`
  display: flex;
  gap: 2rem;
  padding: 2rem;
  background-color: #f1d775;
  border-radius: 3rem;
  border: 0.1rem solid;
`;

//top profile-left column
const LeftColumn = styled.div`
  display: flex;
  flex-direction: column;
  align-items: center;
  width: 30%;
`;

//top profile-right column
const RightColumn = styled.div`
  width: 70%;
  padding: 1rem;
  border-radius: 2rem;
  @media (max-width: 600px) {
      padding: 0;
    }
`;

//top profile-Profile picture
const ProfilePicture = styled.img`
  border-radius: 50%;
  width: 18rem;
  height: 18rem;
  margin: 1rem 0rem 1rem 0rem;
  object-fit: cover;
  transition: 1s ease; 
  overflow: hidden; 
  border:0.4rem,solid;
  &:hover {
    transform: scale(1.1); 
  }
   @media (max-width: 600px) {
      width: 10rem;
      height: 10rem;
      margin: 0;
    }
  }
`;

//top profile- name
const Name = styled.h1`
  margin: 0.5rem;
  text-align: center;
  font-size: 2.5rem;
    @media (max-width: 600px) {
      font-size:2rem;
    }
`;

//top profile- description
const Description = styled.p`
  margin: 0.5rem;
  text-align: center;
  
`;

//top profile- infobox
const InfoBox = styled.div`
  background-color: #f8efcc;
  padding: 2rem;
  border-radius: 3rem;
  height:100%;
  margin:0rem;
  border: 0.2rem solid;
  overflow: hidden;
  h2 {
    margin-bottom: 1rem; /* Başlık ile liste arasındaki boşluk */
    font-size:2.5rem;
  }
  ul{
    list-style-type: none;
    padding: 0;
    margin: 0;

  li{
      margin: 0.5rem 0;
      font-size:1.2rem;
    }
   }
   @media (max-width: 600px) {
      margin: 0 0 0.5rem 0;
      li{
        font-size:1rem;
      }
      h2{
        font-size:2rem;
      }
    }
`;

//top profile- Sub actions
// const SubBox = styled.div`
//   margin: 1rem;
//   background-color: #efcc63;
//   padding: 1rem;
//   border-radius: 3rem;
//   height: 20%;
//   border: 0.2rem solid;
//   display: flex; /* Flex düzeni kullan */
//   justify-content: space-between; /* Butonlar arasında boşluk bırak */
  
//   @media (max-width: 600px) {
//     margin: 0 0 0.5rem 0;
//     flex-direction: column; /* Mobilde butonları alt alta diz */
//     height: auto;
//   }
// `;
const Button = styled.button`
  padding: 0.5rem 1rem;
  border-radius: 1rem;
  border: none;
  background-color: #2e2d28;
  cursor: pointer;
  font-size: 1.5rem;
  font-weight: bold;
  color: #f8efcc;
  margin:1rem;
  &:hover {
    background-color: #2e2d28;
  }
  
  @media (max-width: 600px) {
    margin-bottom: 0.5rem; 
    font-size: 1rem;
  }
`;
const ButtonInfo = styled.button`
  padding: 0.5rem 1rem;
  border-radius: 1rem;
  border: none;
  background-color: #2e2d28;
  cursor: pointer;
  font-size: 1.5rem;
  font-weight: bold;
  color: #f8efcc;
  margin:1rem 1rem 0 0;
  &:hover {
    background-color: #2e2d28;
  }
  
  @media (max-width: 600px) {
    margin-bottom: 0.5rem; 
    font-size: 1rem;
    width: 8rem;
  }
`;
//**bottom profile
const BottomSection = styled.div`
  margin-top: 1rem;
  background-color: #f1d775;
  border-radius:3rem;
  border: 0.1rem solid;
  @media (max-width: 600px) {
    margin-top:0.5rem ;
  }
`;
const ButtonWrapper = styled.div`
  display: flex;
  justify-content: center; 
  align-items: center; 
  height: 100%; 
`;
const ButtonBottom = styled.button`
  padding: 0.5rem 1rem;
  border-radius: 1rem;
  border: none;
  background-color: #2e2d28;
  cursor: pointer;
  font-size: 1.5rem;
  font-weight: bold;
  color: #f8efcc;
  margin:1rem 0rem 2rem 0rem;
  &:hover {
    background-color: #2e2d28; 
  }
  
  @media (max-width: 600px) {
    margin-bottom: 0.5rem; 
  }
`;
//bottom profile table
const Table = styled.table`
  width: 100%;
  border-collapse: separate;
  border-spacing: 1rem;
  th,
  td {
    padding: 1rem;
    border: none;
    background-color: #f8efcc;
    border-radius:2rem;
    font-size: 1.3rem;
  }

  th {
    border-radius:2rem;
    border: 0.2rem solid;
    font-size:1.3rem;
  }
   @media (max-width: 600px) {
    th,
    td {
    font-size: 1rem;
    }

    th {
      border-radius:2rem;
      border: 0.2rem solid;
      font-size:1rem;
    }
  }
`;

