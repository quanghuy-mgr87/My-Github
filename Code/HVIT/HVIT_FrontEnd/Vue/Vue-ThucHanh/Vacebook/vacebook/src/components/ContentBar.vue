<template>
  <div class="col-lg-6 pt-1 px-5 content">
    <div class="row storyRow">
      <div class="col-lg-2 storyCard">
        <div class="card firstCard" style="position: relative;">
          <img id="storyImg" style="height: 130px" :src="userAvatar.huy" alt="" />
          <a class="fas fa-plus-circle" href="#"></a>
          <div style="position: absolute; bottom: 10px;text-align: center; width: 100%;">
            <span>Tạo tin</span>
          </div>
        </div>
      </div>
      <div class="col-lg-2 storyCard">
        <div class="card secondCard" style="position: relative">
          <img id="storyImg" :src="storyImage.mariaStory[0]" alt="" />
          <img id="storyAvatar" :src="userAvatar.maria[0]" alt="" />
          <div style="position: absolute; bottom: 10px; left: 10px">
            <span>mad.mad.alien</span>
          </div>
        </div>
      </div>
      <div class="col-lg-2 storyCard">
        <div class="card thirdCard" style="position: relative">
          <img id="storyImg" :src="storyImage.mariaStory[1]" alt="" />
          <img id="storyAvatar" :src="userAvatar.maria[1]" alt="" />
          <div style="position: absolute; bottom: 10px; left: 10px">
            <span>Мария Золотова</span>
          </div>
        </div>
      </div>
      <div class="col-lg-2 storyCard">
        <div class="card thirdCard" style="position: relative">
          <img id="storyImg" :src="storyImage.mariaStory[1]" alt="" />
          <img id="storyAvatar" :src="userAvatar.maria[1]" alt="" />
          <div style="position: absolute; bottom: 10px; left: 10px">
            <span>Мария Золотова</span>
          </div>
        </div>
      </div>
      <div class="col-lg-2 storyCard">
        <div class="card fourthCard" style="position: relative">
          <img id="storyImg" :src="storyImage.linhStory" alt="" />
          <img id="storyAvatar" :src="userAvatar.linh" alt="" />
          <div style="position: absolute; bottom: 10px; left: 10px">
            <span>linhdo_</span>
          </div>
        </div>
      </div>
      <div class="col-lg-2 storyCard">
        <div class="card fourthCard" style="position: relative">
          <img id="storyImg" :src="storyImage.linhStory" alt="" />
          <img id="storyAvatar" :src="userAvatar.linh" alt="" />
          <div style="position: absolute; bottom: 10px; left: 10px">
            <span>linhdo_</span>
          </div>
        </div>
      </div>
      <a class="fas fa-arrow-circle-right" href="#"></a>
    </div>
    <div class="row mt-4">
      <div class="col-lg-12 pt-2 pl-3 pr-3" style="height: 123px; background-color: #242527; border-radius: 10px">
        <div class="row mb-3">
          <div class="col-lg-1">
            <img class="statusAvatar" :src="userAvatar.huy" alt="" />
          </div>
          <div class="col-lg-11">
            <input type="text" class="form-control status" placeholder="Bạn đang nghĩ gì thế?" />
          </div>
        </div>
        <div class="line"></div>
        <div class="row mt-2 mx-0">
          <!-- style="background-color: #242527; width: 100%; height: 40px; border: none" -->
          <div class="col-lg-4 pt-2 m-0 px-0 statusItem">
            <a class="nav-link" href="#" style="padding: 0px">
              <i class="fas fa-video"></i>
              <span>Video trực tiếp</span>
            </a>
          </div>
          <div class="col-lg-4 pt-2 m-0 px-0 statusItem">
            <a class="nav-link" href="#" style="padding: 0px">
              <i class="fas fa-images"></i>
              <span>Ảnh/Video</span>
            </a>
          </div>
          <div class="col-lg-4 pt-2 m-0 px-0 statusItem">
            <a class="nav-link" href="#" style="padding: 0px">
              <i class="far fa-grin"></i>
              <span>Cảm xúc/Hoạt động</span>
            </a>
          </div>
        </div>
      </div>
    </div>
    <post></post>
  </div>
</template>
<script>
import Post from "./Post.vue";
export default {
  components: {
    Post,
  },
  data() {
    return {
      userAvatar: {
        huy:
          "https://scontent.fhan3-1.fna.fbcdn.net/v/t1.0-9/118641346_1729373410560565_7058860402179674119_o.jpg?_nc_cat=106&_nc_sid=09cbfe&_nc_ohc=AN9QQQM08H0AX9kEjTW&_nc_ht=scontent.fhan3-1.fna&oh=444c57279a86b8780f8637471df289d8&oe=5F7A0F0B",
        maria: [
          "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcR160xJNuIEy676ns4LppT0jDWZxUD_uwLsKg&usqp=CAU",
          "https://instagram.fhan3-2.fna.fbcdn.net/v/t51.2885-15/sh0.08/e35/s750x750/89690453_511475649755547_5161606507901878723_n.jpg?_nc_ht=instagram.fhan3-2.fna.fbcdn.net&_nc_cat=103&_nc_ohc=Vdhkw29RZlMAX90FWoX&oh=00699d13259960c4f4718e1c60305539&oe=5F81AC40",
        ],
        quoc: "https://i.pinimg.com/736x/29/ab/5a/29ab5acafc429ac807f72aece29a5695.jpg",
        linh:
          "https://instagram.fhan3-2.fna.fbcdn.net/v/t51.2885-15/e35/p1080x1080/116227507_647881259474749_8440815342935106578_n.jpg?_nc_ht=instagram.fhan3-2.fna.fbcdn.net&_nc_cat=101&_nc_ohc=gz02I4VVvmYAX-iZvV_&oh=9a6d60b38f8c3e2bef437b1ec380ba4a&oe=5F8129F9",
      },

      storyImage: {
        huyStory:
          "https://scontent.fhan3-1.fna.fbcdn.net/v/t1.0-9/118665729_1726647494166490_8967369214768105628_n.jpg?_nc_cat=104&_nc_sid=0debeb&_nc_ohc=N8Ax3YkwgGsAX_i_PwI&_nc_oc=AQlqFbQspASPtmlKd1DtmoMwCWbBNvfeuT-P3aii1-QAyrMWoCRLF1ePGPo3e3IbzOU&_nc_ht=scontent.fhan3-1.fna&oh=cfaf4cfac627d4c74c1ecf7694298f8c&oe=5F7AB245",
        mariaStory: [
          "https://scontent.fhan3-1.fna.fbcdn.net/v/t1.0-9/118904588_417590529220242_4039607430045584142_n.jpg?_nc_cat=102&_nc_sid=8bfeb9&_nc_ohc=mvSFv0tAdYIAX-1oShM&_nc_oc=AQne7dAMn1qWQAJPRnVPwvoQdLLAJJfMx9lIhMPpwkyE1AJy1kbl6rw74DOG9aYmgDM&_nc_ht=scontent.fhan3-1.fna&oh=bafbed89f83f0b664e716a875f29802d&oe=5F7C4C7D",
          "https://scontent.fhan3-2.fna.fbcdn.net/v/t1.0-9/117039978_392300318415930_3999528415021311407_n.jpg?_nc_cat=107&_nc_sid=8bfeb9&_nc_ohc=AlE7YG1VTvAAX-4WKc1&_nc_ht=scontent.fhan3-2.fna&oh=44b85504ffd9fbab965858b6ef0c6110&oe=5F7D54E1",
        ],
        quoc: ["https://i.pinimg.com/736x/29/ab/5a/29ab5acafc429ac807f72aece29a5695.jpg", "https://thuthuatnhanh.com/wp-content/uploads/2019/05/gai-xinh-toc-ngan-facebook.jpg"],
        linhStory:
          "https://instagram.fhan3-1.fna.fbcdn.net/v/t51.2885-15/e35/p1080x1080/116423302_124192595713770_4341330633689069111_n.jpg?_nc_ht=instagram.fhan3-1.fna.fbcdn.net&_nc_cat=106&_nc_ohc=REesoYWhfeEAX_W6Oe2&oh=359cb2415354e3a96c3daeb37a2b4dca&oe=5F80FF87",
      },
    };
  },
};
</script>
<style scoped></style>
