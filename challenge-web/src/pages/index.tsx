import { Container, Tab, TabList, TabPanels, Tabs, Button, Center } from "@chakra-ui/react";
import { TabPanel } from "@/components/TabPanel";

export default function Home() {
  return (
    <Container maxW='1000px'>
      <p>{process.env.customKey}</p>
      <Tabs isFitted colorScheme="orange">
        <TabList mb='1em'>
          <Tab>Invited</Tab>
          <Tab>Accepted</Tab>
        </TabList>

        <TabPanels>
          <TabPanel status={0} />
          <TabPanel status={1} />
        </TabPanels>
      </Tabs>
    </Container>
  )
}