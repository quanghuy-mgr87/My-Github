<template>
  <v-data-table :headers="headers" :items="studentList" sort-by="Id" class="elevation-1">
    <template v-slot:top>
      <v-toolbar flat color="white">
        <v-toolbar-title>STUDENT LIST</v-toolbar-title>
        <v-divider class="mx-4" inset vertical></v-divider>
        <v-spacer></v-spacer>
        <v-dialog v-model="dialog" max-width="500px">
          <template v-slot:activator="{ on, attrs }">
            <v-btn color="primary" dark class="mb-2" v-bind="attrs" v-on="on">New student</v-btn>
          </template>
          <v-card>
            <v-card-title>
              <span class="headline">{{ formTitle }}</span>
            </v-card-title>

            <v-card-text>
              <v-container>
                <v-row>
                  <v-col cols="12">
                    <v-text-field v-model="editedStudent.hoTen" :rules="[]" label="Student name"></v-text-field>
                  </v-col>
                  <v-col cols="4">
                    <v-text-field v-model="editedStudent.lopId" label="Class"></v-text-field>
                  </v-col>
                  <v-col cols="8">
                    <v-text-field v-model="editedStudent.ngaySinh" label="Date of birth"></v-text-field>
                    <!-- <v-menu ref="menu1" v-model="menu1" :close-on-content-click="false" transition="scale-transition" offset-y max-width="290px" min-width="290px">
                      <template v-slot:activator="{ on, attrs }">
                        <v-text-field
                          v-model="dateFormatted"
                          label="Date"
                          hint="MM/DD/YYYY format"
                          persistent-hint
                          prepend-icon="event"
                          v-bind="attrs"
                          @blur="date = parseDate(dateFormatted)"
                          v-on="on"
                        ></v-text-field>
                      </template>
                      <v-date-picker v-model="date" no-title @input="menu1 = false"></v-date-picker>
                    </v-menu> -->
                  </v-col>
                  <v-col cols="12">
                    <v-text-field v-model="editedStudent.queQuan" label="Address"></v-text-field>
                  </v-col>
                </v-row>
              </v-container>
            </v-card-text>

            <v-card-actions>
              <v-spacer></v-spacer>
              <v-btn color="blue darken-1" text @click="close">Cancel</v-btn>
              <v-btn color="blue darken-1" text @click="save">Save</v-btn>
            </v-card-actions>
          </v-card>
        </v-dialog>
      </v-toolbar>
    </template>
    <template v-slot:[`item.actions`]="{ item }">
      <v-icon small class="mr-2" @click="editStudent(item)">
        mdi-pencil
      </v-icon>
      <v-icon small @click="deleteBtn(item)">
        mdi-delete
      </v-icon>
    </template>
    <!-- <template v-slot:no-data>
      <v-btn color="primary" @click="initialize">Reset</v-btn>
    </template> -->
  </v-data-table>
</template>

<script>
import axios from "axios";
export default {
  data: () => ({
    dialog: false,
    headers: [
      {
        text: "ID",
        align: "start",
        value: "id",
      },
      {
        text: "Student name",
        value: "hoTen",
      },
      { text: "Class", value: "lopId" },
      { text: "Date of birth", value: "ngaySinh" },
      { text: "Address", value: "queQuan" },
      { text: "Actions", value: "actions", sortable: false },
    ],
    studentList: [],
    editedIndex: -1,
    editedStudent: {
      hoTen: "",
      lopId: "",
      ngaySinh: "",
      queQuan: "",
    },
    defaultItem: {
      hoTen: "",
      lopId: "",
      ngaySinh: "",
      queQuan: "",
    },
  }),

  computed: {
    formTitle() {
      return this.editedIndex === -1 ? "New Student" : "Edit Student";
    },
  },

  watch: {
    dialog(val) {
      val || this.close();
    },
  },

  created() {
    this.getStudentList();
  },

  methods: {
    //axios
    getStudentList() {
      axios.get("https://localhost:44389/api/hocsinh").then((res) => {
        // res.data.forEach((val) => {
        //   val.ngaySinh = this.getShortDate(val.ngaySinh);
        // });
        this.studentList = res.data;
        // console.log(this.studentList);
      });
    },

    createStudent(val) {
      axios.post("https://localhost:44389/api/hocsinh", val).then((res) => {
        this.getStudentList();
        alert(`Add ${res.data.hoTen} complete!`);
      });
    },

    deleteStudent(studentId) {
      axios.delete(`https://localhost:44389/api/hocsinh/${studentId}`).then(() => {
        this.getStudentList();
        // alert(`Delete ${res.data.hoTen} complete!`);
      });
    },

    getShortDate(val) {
      let temp = new Date(val);
      let month = temp.getMonth() + 1;
      let date = temp.getDate();
      let year = temp.getFullYear();
      let shortStartDate = date + "/" + month + "/" + year;
      return shortStartDate;
    },

    initialize() {
      this.studentList = [
        {
          id: "",
          hoTen: "",
          lopId: "",
          ngaySinh: "",
          queQuan: "",
        },
      ];
    },

    editStudent(item) {
      this.editedIndex = this.studentList.indexOf(item);
      this.editedStudent = Object.assign({}, item);
      this.dialog = true;
    },

    deleteBtn(item) {
      // const index = this.studentList.indexOf(item);
      confirm("Are you sure you want to delete this item?") && this.deleteStudent(item.id);
      this.getStudentList();
    },

    close() {
      this.dialog = false;
      this.$nextTick(() => {
        this.editedStudent = Object.assign({}, this.defaultItem);
        this.editedIndex = -1;
      });
    },

    resetLst() {
      return this.studentList;
    },

    save() {
      if (this.editedIndex > -1) {
        Object.assign(this.studentList[this.editedIndex], this.editedStudent);
      } else {
        this.createStudent(this.editedStudent);
      }
      this.close();
    },
  },
};
</script>
