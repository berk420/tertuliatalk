// components/EditModal.tsx
import React, { useState } from "react";
import styled from "styled-components";
import Cookies from "js-cookie";

type EditModalProps = {
  showModal: boolean;
  closeModal: () => void;
};

const EditModal: React.FC<EditModalProps> = ({ showModal, closeModal }) => {
  // Kullanıcı bilgileri için state tanımlamaları
  const [username, setUsername] = useState("");
  const [profilePhoto, setProfilePhoto] = useState<File | null>(null);
  const [age, setAge] = useState<number | "">("");
  const [hobbies, setHobbies] = useState("");

  // Kaydet butonu tıklamasında yapılacak işlemler
  const handleSave = async () => {

  const userData = {
    //Burada hangi datalar eklenecek???
    Name: username || null,
    Age: age || null,
    Hobbies: hobbies || null,
    ProfilePhotoUrl: profilePhoto || null 
};


  try {
    const response = await fetch("http://localhost:5199/api/Auth/update-user", {
      method: "PUT",
      headers: {
        "Content-Type": "application/json",
        Authorization: `Bearer ${Cookies.get("token")}` // Token eklemeniz gerekiyor
      },
      body: JSON.stringify(userData)
    });

    if (response.ok) {
      const updatedUser = await response.json();
      console.log("Kullanıcı başarıyla güncellendi:", updatedUser);
      window.location.reload();

    } else {
      console.error("Kullanıcı güncelleme hatası:", response.statusText);
    }
  } catch (error) {
    console.error("Bir hata oluştu:", error);
  }

  closeModal();
};
  return (
    <ModalContainer showModal={showModal}>
      <ModalContent>
     
        <h2>Kullanıcı Bilgilerini Düzenle</h2>

        {/* Kullanıcı Adı Değiştir */}
        <InputContainer>
          <label>Kullanıcı Adı Değiştir:</label>
          <input
            type="text"
            value={username}
            onChange={(e) => setUsername(e.target.value)}
          />
        </InputContainer>

        {/* Profil Fotoğrafı Değiştir */}
        <InputContainer>
          <label>Profil Fotoğrafı Değiştir:</label>
          <input type="text" 
           onChange={(e) => setProfilePhoto(e.target.value)} />
        </InputContainer>

        {/* Yaş Değiştir */}
        <InputContainer>
          <label>Yaş Değiştir:</label>
          <input
            type="number"
            value={age}
            onChange={(e) => setAge(Number(e.target.value))}
          />
        </InputContainer>

        {/* Hobiler Değiştir */}
        <InputContainer>
          <label>Hobiler Değiştir:</label>
          <input
            type="text"
            value={hobbies}
            onChange={(e) => setHobbies(e.target.value)}
          />
        </InputContainer>

        {/* Kaydet ve Kapat Butonları */}
        <ButtonContainer>
          <SaveButton onClick={handleSave}>Kaydet</SaveButton>
          <CloseButton onClick={closeModal}>Kapat</CloseButton>
        </ButtonContainer>
      </ModalContent>
    </ModalContainer>
  );
};
const SaveButton = styled.button`
  padding: 8px 16px;
  cursor: pointer;
  background-color: #2e2d28;
  color: white;
  border: none;
  border-radius: 1rem;
`;

const CloseButton = styled.button`
  padding: 8px 16px;
  cursor: pointer;
  background-color: #2e2d28;
  color: white;
  border: none;
  border-radius: 1rem;
`;
const ButtonContainer = styled.div`
  display: flex;
  justify-content: space-between;
  margin-top: 20px;
`;

const ModalContainer = styled.div<{ showModal: boolean }>`
  display: ${({ showModal }) => (showModal ? "flex" : "none")};
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background-color: rgba(0, 0, 0, 0.5);
  justify-content: center;
  align-items: center;
  z-index: 1000;
`;

const ModalContent = styled.div`
  background: #f8efcc;
  padding: 20px;
  border-radius: 1rem;
  width: 25%;
  height: auto;
  box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
  text-align: center;
`;

const InputContainer = styled.div`
  margin: 10px 0;
  text-align: left;
  display: flex;
  flex-direction: column;
  align-items: center;

  label {
    margin-bottom: 5px;
    font-size: 1.4rem;
  }

  input {
    width: 70%;
    padding: 8px;
    margin-top: 5px;
    border-radius: 2rem;

  }
`;

export default EditModal;
