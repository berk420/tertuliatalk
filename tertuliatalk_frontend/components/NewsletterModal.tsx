import React, { useState } from 'react';
import MailchimpSubscribe, { DefaultFormFields } from 'react-mailchimp-subscribe';
import styled from 'styled-components';
import { EnvVars } from 'env';
import useEscClose from 'hooks/useEscKey';
import { media } from 'utils/media';
import Button from './Button';
import CloseIcon from './CloseIcon';
import Container from './Container';
import Input from './Input';
import MailSentState from './MailSentState';
import Overlay from './Overlay';
import NextLink from 'next/link';
import { signIn } from 'services/AuthService'; // Import signIn function

export interface NewsletterModalProps {
  onClose: () => void;
}

export default function NewsletterModal({ onClose }: NewsletterModalProps) {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');

  useEscClose({ onClose });

  async function onSubmit(event: React.FormEvent<HTMLFormElement>) {
    event.preventDefault();
    console.log("girmeden")
    if (email && password) {
      console.log("girince")

      const result = await signIn(email, password);
      console.log(result);
      console.log(result.role);
      if (result) {
        console.log("Sign-in successful:", result);
      } else {
        console.log("Sign-in failed");
      }
    }
  }

  function handleButtonClick(event: React.MouseEvent<HTMLButtonElement>) {
    event.preventDefault();

    const form = event.currentTarget.closest('form');
    if (form) {
      form.dispatchEvent(new Event('submit', { cancelable: true, bubbles: true }));
    }
  }

  function handleLinkClick() {
    onClose(); // Close the modal
  }

  return (
    <Overlay>
      <Container>
        <Card onSubmit={onSubmit}>
          <CloseIconContainer>
            <CloseIcon onClick={onClose} />
          </CloseIconContainer>
          <>
            <Title>Giriş yap</Title>
            <Row>
              <CustomInput
                value={email}
                onChange={(e: React.ChangeEvent<HTMLInputElement>) => setEmail(e.target.value)}
                placeholder="Email adresinizi giriniz..."
                required
              />
            </Row>
            <Row>
              <CustomInput
                type="password"
                value={password}
                onChange={(e: React.ChangeEvent<HTMLInputElement>) => setPassword(e.target.value)}
                placeholder="Şifrenizi giriniz..."
                required
              />
            </Row>
            <Row>
              <CustomButton as="button" type="submit" onClick={handleButtonClick}>
                Submit
              </CustomButton>
            </Row>
            <Row>
              <a onClick={handleLinkClick}>
                You can Sign up from{' '}
                <NextLink href="/signup">
                  <a>here.</a>
                </NextLink>
              </a>
            </Row>
          </>
        </Card>
      </Container>
    </Overlay>
  );
}

const Card = styled.form`
  display: flex;
  position: relative;
  flex-direction: column;
  margin: auto;
  padding: 10rem 5rem;
  background: rgb(var(--modalBackground));
  border-radius: 0.6rem;
  max-width: 70rem;
  overflow: hidden;
  color: rgb(var(--text));

  ${media('<=tablet')} {
    padding: 7.5rem 2.5rem;
  }
`;

const CloseIconContainer = styled.div`
  position: absolute;
  right: 2rem;
  top: 2rem;

  svg {
    cursor: pointer;
    width: 2rem;
  }
`;

const Title = styled.div`
  font-size: 3.2rem;
  font-weight: bold;
  line-height: 1.1;
  letter-spacing: -0.03em;
  text-align: center;
  color: rgb(var(--text));

  ${media('<=tablet')} {
    font-size: 2.6rem;
  }
`;

const Row = styled.div`
  display: flex;
  justify-content: center;
  align-items: center;
  height: 100%;
  width: 100%;
  margin-top: 3rem;

  ${media('<=tablet')} {
    flex-direction: column;
  }
`;

const CustomButton = styled(Button)`
  height: 100%;
  padding: 1.8rem;
  margin-left: 1.5rem;
  box-shadow: var(--shadow-lg);

  ${media('<=tablet')} {
    width: 100%;
    margin-left: 0;
    margin-top: 1rem;
  }
`;

const CustomInput = styled(Input)`
  width: 60%;

  ${media('<=tablet')} {
    width: 100%;
  }
`;
