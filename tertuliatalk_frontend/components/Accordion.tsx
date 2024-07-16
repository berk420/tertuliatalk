import { PropsWithChildren, useState } from 'react';
import styled from 'styled-components';
import { media } from 'utils/media';
import Collapse from './Collapse';
import RichText from './RichText';
import { ColumnFlex, RowFlex } from 'pages/weekly-session-schedule';
import { Roles } from 'types/enums';
import { IoMdAdd } from "react-icons/io";
import { Cursor } from './Meeting';
import MeetingAddForm from './MeetingAddForm';
import { set } from 'lodash';

interface AccordionProps {
  title: string;
  subTitle?: string;
  isOpen?: boolean;
}

type User = {
  id: string;
  role: string;
}

const user: User = {
  id: '1',
  role: Roles.TEACHER,
}

export default function Accordion({ title, subTitle, isOpen, children }: PropsWithChildren<AccordionProps>) {
  const [hasCollapsed, setHasCollapsed] = useState(!isOpen);
  const isActive = !hasCollapsed;
  const [fromArea, setFromArea] = useState(false)

  const manageDiv = () => {
    if (fromArea) {
      setFromArea(false)
    }
    else if (!fromArea) {
      setFromArea(true)
      setHasCollapsed(true)
    }
    else if (!hasCollapsed) {
      setFromArea(true)
      setHasCollapsed(false)
    }
  }

  return (
    <AccordionWrapper>
      <TitleWrapper>
        <ColumnFlex onClick={() => setHasCollapsed((prev) => !prev)}>
          <Title>{title}</Title>
          <h2>{subTitle}</h2>
        </ColumnFlex>
        <Cursor>
          <RowFlex>
            {
              user.role === Roles.TEACHER && <IoMdAdd size={32} onClick={manageDiv} />
            }
            <Icon isActive={isActive} onClick={() => setHasCollapsed((prev) => !prev)}>
              <svg
                viewBox="0 0 24 24"
                focusable="false"
                className="chakra-icon chakra-accordion__icon css-j2ph2z"
                aria-hidden="true"
                preserveAspectRatio="none"
              >
                <path fill="currentColor" d="M16.59 8.59L12 13.17 7.41 8.59 6 10l6 6 6-6z"></path>
              </svg>
            </Icon>
          </RowFlex>
        </Cursor>
      </TitleWrapper>
      <Collapse isOpen={isActive} duration={300}>
        <Description>
          <RichText>{children}</RichText>
        </Description>
      </Collapse>
      <Collapse isOpen={fromArea} duration={300}>
        <MeetingAddForm />
      </Collapse>
    </AccordionWrapper>
  );
}

const Title = styled.h3`
  cursor: pointer;
  font-size: 2rem;
  width: 100%;
  overflow: hidden;
  text-overflow: ellipsis;
  display: -webkit-box;
  -webkit-box-orient: vertical;
  -webkit-line-clamp: 1;
`;

const TitleWrapper = styled.div`
  display: flex;
  justify-content: space-between;
  align-items: center;
`;

const Icon = styled.div<{ isActive: boolean }>`
  width: 3.4rem;
  transition: transform 0.3s;
  transform: rotateZ(${(p) => (p.isActive ? 180 : 0)}deg);
`;

const Description = styled.div`
  margin-top: 2.5rem;
  font-size: 1.6rem;
  font-weight: normal;
`;

const AccordionWrapper = styled.div`
  display: flex;
  flex-direction: column;
  padding: 2rem 1.5rem;
  background: #191f29;
  box-shadow: var(--shadow-md);
  border-radius: 0.6rem;
  transition: opacity 0.2s;

  ${media('<=desktop')} {
    width: 100%;
  }
`;
