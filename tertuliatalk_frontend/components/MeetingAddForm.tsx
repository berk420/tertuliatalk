import React from 'react';
import { useForm } from 'react-hook-form';
import styled from 'styled-components';
import Button from './Button';

type MeetingAddFormProps = {
  title: string;
  description: string;
  time: string;
  limit: number;
}

const MeetingAddForm = () => {
  const formRef = React.useRef<HTMLFormElement>(null);
  const { register, handleSubmit, formState: { errors } } = useForm();

  const onSubmit = (data: MeetingAddFormProps) => {
    // api post data
    console.log(data);
    formRef.current?.reset();
  }

  return (
    <FormWrapper onSubmit={handleSubmit(onSubmit)} ref={formRef}>
      <TitleWrapper>
        <Label htmlFor="title">Başlık</Label>
        <Input
          id="title"
          {...register('title', { required: true })}
        />
        {errors.title && <ErrorMessage>Başlık zorunludur</ErrorMessage>}
      </TitleWrapper>

      <DescriptionWrapper>
        <Label htmlFor="description">Açıklama</Label>
        <TextArea
          id="description"
          {...register('description', { required: true })}
        />
        {errors.description && <ErrorMessage>Açıklama zorunludur</ErrorMessage>}
      </DescriptionWrapper>

      <TimeWrapper>
        <Label htmlFor="time">Saat</Label>
        <Input
          type="time"
          id="time"
          {...register('time', { required: true })}
        />
        {errors.time && <ErrorMessage>Saat zorunludur</ErrorMessage>}
      </TimeWrapper>

      <QuotaWrapper>
        <Label htmlFor="limit">Kontenjan</Label>
        <Input
          type="number"
          id="limit"
          {...register('limit', { required: true, min: 1 })}
        />
        {errors.quota && <ErrorMessage>Kontenjan zorunludur ve en az 2 olmalıdır</ErrorMessage>}
      </QuotaWrapper>

      <Button type="submit">Dersi Ekle</Button>
    </FormWrapper>
  );
  // this form can be updated according to the requirements of the program features
};

export default MeetingAddForm;

const FormWrapper = styled.form`
  display: flex;
  flex-direction: column;
  gap: 1rem;
  max-width: 400px;
  margin: auto;
  padding: 1rem;
  border: 1px solid #ccc;
  border-radius: 8px;
  box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
`;

const TitleWrapper = styled.div`
  display: flex;
  flex-direction: column;
`;

const DescriptionWrapper = styled.div`
  display: flex;
  flex-direction: column;
`;

const TimeWrapper = styled.div`
  display: flex;
  flex-direction: column;
`;

const QuotaWrapper = styled.div`
  display: flex;
  flex-direction: column;
`;

const Label = styled.label`
  margin-bottom: 0.5rem;
  font-weight: bold;
`;

const Input = styled.input`
  outline: none;
  padding: 0.5rem;
  border: 1px solid #ccc;
  border-radius: 4px;
  font-size: 1.4rem;
`;

const TextArea = styled.textarea`
  outline: none;
  padding: 0.5rem;
  border: 1px solid #ccc;
  border-radius: 4px;
  font-size: 1.5rem;
  resize: vertical;
  max-height: 80px;
`;

const ErrorMessage = styled.span`
  color: red;
  font-size: 0.875rem;
`;